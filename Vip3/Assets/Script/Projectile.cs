using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Enemy")) Destroy(gameObject);
    }
    [SerializeField] private float speed;
    private void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }
}
