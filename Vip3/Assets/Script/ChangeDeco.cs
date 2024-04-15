using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDeco : MonoBehaviour
{
    SpriteRenderer spriterRend;
    public List<Sprite> treeList;
    bool moveOffset = false;
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
                spriterRend.sprite = treeList[0];
                break;
            case SpriteState.Dark:
                spriterRend.sprite = treeList[1];
                break;
            case SpriteState.Night:
                
                spriterRend.sprite = treeList[2];
                if (!moveOffset)
                {
                    transform.position -= new Vector3(0, 0.2f);
                    moveOffset = true;
                }
                break;
            case SpriteState.Spooky:
                spriterRend.sprite = treeList[3];
                break;
            default:
                break;
        }
    }
}
