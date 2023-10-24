using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SwordAttack swordAttack;
    public float swordCooldownRate = 0.5f;
    private float counter = 0;
    private Boolean cooldown = false;    
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (cooldown) // Timer for attack cooldown
        {
            counter += Time.deltaTime;
            if (counter >= swordCooldownRate)
            {
                counter = 0;
                cooldown = false;
            }
        }        
    }

    void OnFire()
    {
        if (!cooldown)
        {
            animator.SetTrigger("swordAttack");
            cooldown = true;
        }        
    }

    public void SwordAttack()
    {
        swordAttack.Attack();
    }

    public void StopAttack()
    {
        //UnlockMovement();
        swordAttack.StopAttack();
    }
}
