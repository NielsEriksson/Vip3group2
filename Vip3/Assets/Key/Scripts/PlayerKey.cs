using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKey : MonoBehaviour
{
    // Start is called before the first frame update
    //PlayerPrefs.HasKey("PlayerHasKey") == 1 - Player has picked up the key
    //PlayerPrefs.HasKey("PlayerHasKey") == 2 - Player has unlocked door
    void Start()
    {
        if(!PlayerPrefs.HasKey("PlayerHasKey"))
        {
            gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("PlayerHasKey") == 2)
        {
            Destroy(gameObject);
        }
    }

    
}
