using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [SerializeField] 
    private float moveSpeed = 0f;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField] 
    private SpriteRenderer spriteRenderer;

    private Transform target;
    private int pathIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = LevelManager.main.path[pathIndex];

        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(target.position,transform.position) <= 0.1f)
        {
            pathIndex++;
           
            if (pathIndex == LevelManager.main.path.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];
            } 
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }

    public void StartMoving()
    {
        this.moveSpeed = 2f;

        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }
    }
}
