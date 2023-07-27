using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : Enemy
{
    public int horizontalDirection; // horizontal direction of movement, left or righ (1 or -1)
    public int verticalDirection; //verttical direction of movement, left or righ (1 or -1)
    [SerializeField] float speed; //movement speed
    private Vector2 startPosition;
    private bool moveRight = true;

    void Start()
    {
        startPosition = transform.position;
    }
    public override void EnemyMovement()
    {
        Vector2 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        if (transform.position.x >= stageDimensions.x) //go to left if at the right edge of screen
        {
            moveRight = false;
        }
        else if (transform.position.x <= -stageDimensions.x) //go to right if at the left edge of screen
        {
            moveRight = true;
        }
    }

    private void Update()
    {
        EnemyMovement();
        if (moveRight)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
    }
    void MoveRight()
    {
        startPosition += Vector2.right * Time.deltaTime * speed;
        transform.position = startPosition + Vector2.up * Mathf.Sin(Time.time * speed / 3) * 1;
    }
    void MoveLeft()
    {
        startPosition -= Vector2.right * Time.deltaTime * speed;
        transform.position = startPosition + Vector2.up * Mathf.Sin(Time.time * speed / 3) * 1;
    }
}