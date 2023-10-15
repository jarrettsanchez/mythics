using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public SwordAttack swordAttack;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }

    public void SwordAttack()
    {
        swordAttack.AttackRight();
    }

    public void StopAttack()
    {
        //UnlockMovement();
        swordAttack.StopAttack();
    }
}
