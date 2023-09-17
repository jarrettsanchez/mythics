using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;

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

            if(_health <= 0)
            {
                isAlive(false);
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

    public void isHit()
    {
        animator.SetTrigger("isHit");
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
}
