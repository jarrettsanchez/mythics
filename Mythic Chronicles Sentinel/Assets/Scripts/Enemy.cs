using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Attributes")]
    [SerializeField] private int currencyWorth = 5;

    Animator animator;

    private bool isDestroyed = false;

    public float _health = 5;

    public float Health
    {
        set
        {
            if(value < _health)
            {
                animator.SetTrigger("isHit");
            }

            _health = value;

            if(_health <= 0 && !isDestroyed)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                LevelManager.main.IncreaseCurrency(currencyWorth);
                isDestroyed = true;
                isAlive(false);
                Destroy(gameObject.GetComponent<CapsuleCollider2D>());
            }
        }
        get
        {
            return _health;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        isAlive(true);
    }

    public void isAlive(bool isAlive)
    {
        animator.SetBool("isAlive", isAlive);
    }

    public void isMoving()
    {
        animator.SetTrigger("isMoving");
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }

    public void OnHit(float damage)
    {
        Health -= damage;
        animator.SetTrigger("isHit");
    }
}
