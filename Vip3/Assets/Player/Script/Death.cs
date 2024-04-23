using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Transform respawnPoint;
    public Transform playerPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       /* if (collision.CompareTag("Player"))
        {*/
            Debug.Log("hit");
            playerPos.position = respawnPoint.position;
       // }
    }
}
