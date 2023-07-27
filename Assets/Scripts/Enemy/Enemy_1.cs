using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy
{
    private Rigidbody2D enemyRb;
    public int direction; //direction of movement, left or righ (1 or -1)
    [SerializeField] float speed; //movement speed
    public float rayDist;
    private bool movingRight = true;
    public Transform groundDetect;

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
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position, Vector2.down, rayDist);

        EnemyMovement();
        if (groundCheck.collider == false)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3 (0, -180, 0);
                direction = -1;
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                direction = 1;
                movingRight = true;
            }
        }

        if (transform.position.x >= stageDimensions.x) //go to left if at the right edge of screen
        {
            transform.eulerAngles = new Vector3 (0, -180, 0);
            direction = -1;
        }
        else if (transform.position.x <= -stageDimensions.x) //go to right if at the left edge of screen
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
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