using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : Enemy
{
    public int horizontalDirection; // horizontal direction of movement, left or righ (1 or -1)
    public int verticalDirection; //verttical direction of movement, left or righ (1 or -1)
    [SerializeField] float speed; //movement speed
    private Vector3 startPosition;
    private bool moveRight = true;
    
    void Start()
    {
        startPosition = transform.position;
    }
    public override void EnemyMovement()
    {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
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
        startPosition += transform.right * Time.deltaTime * speed;
        transform.position = startPosition + transform.up * Mathf.Sin(Time.time * speed) * 0.5f;
    }
    void MoveLeft()
    {
        startPosition -= transform.right * Time.deltaTime * speed;
        transform.position = startPosition + transform.up * Mathf.Sin(Time.time * speed) * 0.5f;
    }
}
