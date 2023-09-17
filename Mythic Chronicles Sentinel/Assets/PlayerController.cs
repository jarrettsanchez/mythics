using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {   // if movement input is not 0, try to move
        if(movementInput != Vector2.zero)
        {
            int count = rb.Cast(
                movementInput,  // X and Y values between -1 and 1, represents direction from body to look for collisions
                movementFilter, // Settings that determine where collision can occur on such as layers to collide with
                castCollisions, // List of collisions to store found collisions into after Cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset); // Amount to cast equal to movement plus offset

            if(count == 0)
            {
                // ensures consistent movement regardless of frame updates
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            }
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
}
