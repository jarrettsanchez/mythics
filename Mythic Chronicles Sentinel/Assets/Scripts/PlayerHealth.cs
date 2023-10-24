using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Jarrett
public class PlayerHealth : MonoBehaviour, IDamageable
{
    Animator animator;

    private const float MIN_HP = 0.0f;

    public float _health = 10.0f;   // base HP
    public HealthBar healthBar;


    private void Start()
    {
        animator = GetComponent<Animator>();
        healthBar.SetMaxHealth(_health);    // set max health
    }

    public float Health
    {
        set
        {
            if (value < _health)
            {
                animator.SetTrigger("IsHit");
            }

            _health = value;

            // if health reaches/drops below 0:
            if (_health <= MIN_HP)
            {
                // switch to game over scene
                SceneManager.LoadScene("GameOver");
            }
        }
        get
        {
            return _health;
        }
    }

    public void OnHit(float damage)
    {
        Health -= damage;
        healthBar.SetHealth(_health - damage);  // update health bar
    }
}
