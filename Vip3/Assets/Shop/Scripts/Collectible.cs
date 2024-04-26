using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    private enum CollectibleType
    {
        Star,
        Coin
    }
    [SerializeField] private CollectibleType type;
    [SerializeField] private Sprite[] starSprites;
    int starSpriteIndex = 0;//will be used to change star sprite for upgrade (Will only work if we have 1 different sprite, if we have more i will need to find an other way of doing it)
    [SerializeField] private Sprite[] coinSprites;
    int coinSpriteIndex = 0;//will be used to change coin sprite for upgrade
    private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        
        switch (type)
        {
            case CollectibleType.Star:
                {
                    sp.sprite = starSprites[starSpriteIndex];
                    break;
                }

            case CollectibleType.Coin:
                {
                    sp.sprite = coinSprites[coinSpriteIndex];
                    break;
                }
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch (type)
            {
                case CollectibleType.Star:
                    {
                        CurrencyManager.Instance.ChangeStarCount(1);
                        break;
                    }

                case CollectibleType.Coin:
                    {
                        CurrencyManager.Instance.ChangeCoinCount(1);
                        break;
                    }
            }
            Destroy(gameObject);
        }
    }

}
