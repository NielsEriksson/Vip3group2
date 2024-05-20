using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyObject : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject PlayerKey;
    void Start()
    {
        PlayerKey = GameObject.FindWithTag("PlayerKey");
        if (PlayerPrefs.HasKey("PlayerHasKey"))
        {
           Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("PlayerHasKey", 1);
            PlayerKey.SetActive(true);
            Destroy(gameObject);
        }
    }
}
