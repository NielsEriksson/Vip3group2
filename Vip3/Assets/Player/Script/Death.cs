using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    protected Transform respawnPoint;
    protected Transform playerPos;


    public virtual void Start()
    {
        respawnPoint = GameObject.FindWithTag("RespawnPoint").transform;
        playerPos = GameObject.FindWithTag("Player").transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Respawn();
        }
    }

    public virtual void Respawn()
    {
        Debug.Log("hit");
        playerPos.position = respawnPoint.position;
    }
}
