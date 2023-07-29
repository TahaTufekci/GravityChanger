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
    private bool isPLayerUpsideDown;

    GManager gameManager;

    
    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GManager>();
    }
    
    void Update()
    {
        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));

        if (Input.GetMouseButtonDown(0))
        {
            playerRb.gravityScale *= -1;
            if (isPLayerUpsideDown)
            {
                transform.eulerAngles = new Vector3 ((0) , transform.position.y, 0);
                isPLayerUpsideDown = false;
            }
            else
            {
                transform.eulerAngles = new Vector3 ((180) , transform.position.y, 0);
                isPLayerUpsideDown = true;
            }
        }
        if (!stopMovement)
        {
            transform.Translate(transform.right * speed * direction * Time.deltaTime);
            if (transform.position.x >= stageDimensions.x) //go to left if at the right edge of screen
            {
                transform.eulerAngles = new Vector3 (transform.position.x, -180, 0);
                direction = -1;
            }
            else if (transform.position.x <= -stageDimensions.x) //go to right if at the left edge of screen
            {
                transform.eulerAngles = new Vector3 (transform.position.x, 0, 0);
                direction = 1;
            }

            if (transform.position.y >= stageDimensions.y)
            {
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -stageDimensions.y, stageDimensions.y),transform.position.z);
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("End"))
        {
            AudioManager.Instance.PlaySound("WinSFX");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            gameManager.SaveData();
            gameManager.LoadNextLevel();


        }
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            AudioManager.Instance.PlaySound("LoseSFX");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}