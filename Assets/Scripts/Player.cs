using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int direction; //direction of movement, left or righ (1 or -1)
    [SerializeField] float speed; //movement speed
    public bool stopMovement;
    private Rigidbody2D playerRb;
    private Vector2 stageDimensions;
    int originalXRotation, originalYRotation;
    

    GameManager gameManager;

    
    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }
    
    void Update()
    {
        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));


        if (!stopMovement)
        {
            transform.Translate(transform.right * speed * direction * Time.deltaTime);
            if (transform.position.x >= stageDimensions.x) //go to left if at the right edge of screen
            {
                transform.eulerAngles = new Vector3 (originalXRotation, -180, 0);
                originalYRotation = -180;
                direction = -1;
            }
            else if (transform.position.x <= -stageDimensions.x) //go to right if at the left edge of screen
            {
                transform.eulerAngles = new Vector3 (originalXRotation, 0, 0);
                originalYRotation = 0;
                direction = 1;
            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject.FindObjectOfType<AudioManager>().playSound("Click");
            playerRb.gravityScale *= -1;
            if (playerRb.gravityScale > 0)
            {
                transform.eulerAngles = new Vector3((0), originalYRotation, 0);
                originalXRotation = 0;
            }
            else
            {
                transform.eulerAngles = new Vector3((180), originalYRotation, 0);
                originalXRotation = 180;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("End"))
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            gameManager.SaveData();
            gameManager.LoadNextLevel();


        }
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            GameObject.FindObjectOfType<AudioManager>().playSound("Death");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}