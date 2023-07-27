using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy
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
        transform.Translate(transform.right * speed * direction * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Vector2 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        EnemyMovement();
        if (transform.position.x >= stageDimensions.x) //go to left if at the right edge of screen
        {
            direction = -1;
        }
        else if (transform.position.x <= -stageDimensions.x) //go to right if at the left edge of screen
        {
            direction = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Barrier"))
        {
            direction *= -1;
        }
    }
}