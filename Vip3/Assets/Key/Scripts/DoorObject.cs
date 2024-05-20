using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObject : MonoBehaviour
{
    private void Start()
    {
        if(PlayerPrefs.GetInt("PlayerHasKey") == 2)
        {
            Destroy(GameObject.FindWithTag("PlayerKey"));
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player" && PlayerPrefs.GetInt("PlayerHasKey")==1)
        {
            PlayerPrefs.SetInt("PlayerHasKey", 2);
            Destroy(GameObject.FindWithTag("PlayerKey"));
            Destroy(gameObject);
        }
    }
}
