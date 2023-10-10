using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //public float moveSpeed = 1f;
    //public float collisionOffset = 0.05f;
    //public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;

    // Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    //List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /*
    private void FixedUpdate()
    {   
        if(canMove)
        {
            // if movement input is not 0, try to move
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));
                }

                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }

                animator.SetBool("isMoving", success);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            // set direction of sprite to movement direction
            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
    }
*/

    /*
    private bool TryMove(Vector2 direction)
    {
        if(direction != Vector2.zero) {
            // Check potential collisions
            int count = rb.Cast(
                direction,  // X and Y values between -1 and 1, represents direction from body to look for collisions
                movementFilter, // Settings that determine where collision can occur on such as layers to collide with
                castCollisions, // List of collisions to store found collisions into after Cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset); // Amount to cast equal to movement plus offset

            if (count == 0)
            {
                // ensures consistent movement regardless of frame updates
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            // cannot move if no direction to move in
            return false;
        }
    }
*/

/*
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
*/

    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }

    public void SwordAttack()
    {
        LockMovement();
        if(spriteRenderer.flipX == true)
        {
            swordAttack.AttackLeft();
        }
        else
        {
            swordAttack.AttackRight();
        }
    }

    public void StopAttack()
    {
        UnlockMovement();
        swordAttack.StopAttack();
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }
}
