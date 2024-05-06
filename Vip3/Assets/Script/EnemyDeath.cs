using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : Death
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // get the direction of the collision
        Vector3 direction = transform.position - collision.gameObject.transform.position;
        // see if the obect is futher left/right or up down
        if (Mathf.Abs(direction.x) <= Mathf.Abs(direction.y) && direction.y > 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Respawn();
        }

    }
}
