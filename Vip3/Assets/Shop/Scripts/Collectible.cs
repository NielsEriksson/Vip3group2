using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType
    {
        Star,
        Coin
    }
    [SerializeField] public CollectibleType type;
    [SerializeField] private Sprite[] starSprites;
    int starSpriteIndex = 0;//will be used to change star sprite for upgrade (Will only work if we have 1 different sprite, if we have more i will need to find an other way of doing it)
    [SerializeField] private Sprite[] coinSprites;
    int coinSpriteIndex = 0;//will be used to change coin sprite for upgrade
    [HideInInspector] public SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        CurrencyManager.Instance.allCollectibles.Add(this);
        SetSprites();
    }
    public void SetSprites()
    {
        switch (type)
        {
            case CollectibleType.Star:
                {
                    sp.sprite = starSprites[starSpriteIndex];
                    break;
                }

            case CollectibleType.Coin:
                {
                    if (!UpgradeManager.Instance.coins) { gameObject.SetActive(false); }//Destroys the coin game object if coins upgrade is not unlocked yet

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
                       // AudioManager.Instance.PlaySFX(Sound.PickUp);

                        break;
                    }

                case CollectibleType.Coin:
                    {
                        CurrencyManager.Instance.ChangeCoinCount(1);
                        AudioManager.Instance.PlaySFX(Sound.PickUp);

                        break;
                    }
            }
            Destroy(gameObject);
        }
    }

}
