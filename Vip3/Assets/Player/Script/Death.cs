using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Transform respawnPoint;
    protected Transform playerPos;


    public virtual void Start()
    {
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
        AudioManager.Instance.PlaySFX(Sound.Death);
        CameraMovement.instance.RecenterCamera();
    }
}
