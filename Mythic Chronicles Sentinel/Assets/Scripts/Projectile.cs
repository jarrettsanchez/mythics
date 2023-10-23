using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private int projectileDmg = 2;

    private Transform target;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        if(!target)
        {
            Destroy(gameObject); 
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * projectileSpeed;

        if(target.position.x > rb.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if(target.position.x < rb.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damagableObject = other.GetComponent<IDamageable>();

        if (other.CompareTag("Enemy"))
        {
            if (damagableObject != null)
            {
                damagableObject.OnHit(projectileDmg);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Collider does not implement IDamageable.");
            }
        }
    }
}
