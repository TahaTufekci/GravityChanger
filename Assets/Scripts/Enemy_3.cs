using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3 : Enemy
{
    private Rigidbody2D enemyRb;
    public int direction; //direction of movement, left or righ (1 or -1)
    [SerializeField] float speed; //movement speed

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    public override void EnemyMovement()
    {
        transform.Translate(transform.up * speed * direction * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        EnemyMovement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Barrier"))
        {
            direction *= -1;
        }
    }
}