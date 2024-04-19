using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    SpriteRenderer spriterRend;
    public List<Sprite> variantList;
    void Start()
    {
        spriterRend = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (SpriteChangeManager.Instance.spriteState)
        {
            case SpriteState.Bright:
                spriterRend.sprite = variantList[0];
                break;
            case SpriteState.Dark:
                spriterRend.sprite = variantList[1];
                break;
            case SpriteState.Night:                
                spriterRend.sprite = variantList[2];
                break;
            case SpriteState.Spooky:
                spriterRend.sprite = variantList[3];
                break;
            default:
                break;
        }
    }
}
