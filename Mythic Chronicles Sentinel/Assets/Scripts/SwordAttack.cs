using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public float damage = 2f;
    Vector2 attackOffset;

    private void Start()
    {
        attackOffset = transform.position;
    }

    public void Attack()
    {
        swordCollider.enabled = true;
        transform.position = attackOffset;
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damagableObject = other.GetComponent<IDamageable>();

        if(other.CompareTag("Enemy"))
        {
            if(damagableObject != null)
            {
                damagableObject.OnHit(damage);
            }
            else
            {
                Debug.LogWarning("Collider does not implement IDamageable.");
            }
        }
    
    }
}
