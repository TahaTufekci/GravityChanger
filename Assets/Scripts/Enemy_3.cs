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

    private void Update()
    {
        EnemyMovement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            direction *= -1;
        }
    }
}