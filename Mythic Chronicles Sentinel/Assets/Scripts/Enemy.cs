using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Attributes")]
    [SerializeField] private int currencyWorth = 5;

    Animator animator;

    private bool isDestroyed = false;
    private const float MIN_HP = 0.0f;

    public float _health = 5;   // base HP
    public float damage = 1;    // base damage to character

    public float Health
    {
        set
        {
            if(value < _health)
            {
                animator.SetTrigger("isHit");
            }

            _health = value;

            // if health reaches/drops below 0 and the game object is not destroyed:
            if(_health <= MIN_HP && !isDestroyed)
            {
                EnemySpawner.onEnemyDestroy.Invoke();                   // invoke counter functionsn in EnemySpawner
                LevelManager.main.IncreaseCurrency(currencyWorth);      // increase currency
                isDestroyed = true;                                     // set destroyed flag to true
                isAlive(false);                                         // play sprite's death animation
                Destroy(gameObject.GetComponent<CapsuleCollider2D>());  // destroy enemy's collider
            }
        }
        get
        {
            return _health;
        }
    }

    // get enemy animator, set isAlive flag to true
    private void Start()
    {
        animator = GetComponent<Animator>();
        isAlive(true);
    }

    // animate sprite to its idle animation
    public void isAlive(bool isAlive)
    {
        animator.SetBool("isAlive", isAlive);
    }

    // animate sprite to its moving animation
    public void isMoving()
    {
        animator.SetTrigger("isMoving");
    }

    // destroys enemy
    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }

    // deal damage to enemy, play damaged enemy animation
    public void OnHit(float damage)
    {
        Health -= damage;
        animator.SetTrigger("isHit");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageableObject = collision.collider.GetComponent<IDamageable>();

        if (damageableObject != null)
        {
            damageableObject.OnHit(damage);
        }
    }
}
