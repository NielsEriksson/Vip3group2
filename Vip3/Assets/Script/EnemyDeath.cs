using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : Death
{
    [SerializeField] private GameObject collectiblePrefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 direction = collision.GetContact(0).normal;
        // see if the obect is futher left/right or up down
       
        if (direction.y <= -0.8f)
        {
            SpawnCoin();
            Destroy(gameObject);
        }
        else
        {
            Respawn();
        }
    }

    private void SpawnCoin()
    {
        GameObject coin = Instantiate(collectiblePrefab, transform.position+new Vector3(2.5f,0,0),Quaternion.identity);
        coin.GetComponent<Collectible>().type = Collectible.CollectibleType.Coin;
        coin.GetComponent<Collectible>().sp = coin.GetComponent<SpriteRenderer>();
        coin.GetComponent<Collectible>().SetSprites();
    }
}
