using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int direction; //direction of movement, left or righ (1 or -1)
    [SerializeField] float speed; //movement speed
    public bool stopMovement;
    private Rigidbody2D playerRb;
    private Vector2 stageDimensions;
    
    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        if (!stopMovement)
        {
            transform.Translate(transform.right * speed * direction * Time.deltaTime);
            if (transform.position.x >= stageDimensions.x) //go to left if at the right edge of screen
            {
                direction = -1;
            }
            else if (transform.position.x <= -stageDimensions.x) //go to right if at the left edge of screen
            {
                direction = 1;
            }

            if (transform.position.y >= stageDimensions.y)
            {
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -stageDimensions.y, stageDimensions.y),transform.position.z);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            playerRb.gravityScale *= -1;
        }
    }
}