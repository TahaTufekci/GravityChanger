using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    GManager gameManager;
    public LayerMask playerMask;

    private void Awake()
    {
        gameManager = FindObjectOfType<GManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & playerMask)!=0)
        {
            gameManager.SaveData();
            gameManager.LoadNextLevel();
        }
    }

}
