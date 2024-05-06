using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag !="Enemy") Destroy(gameObject);
    }
    [SerializeField] private float speed;
    [HideInInspector] public Vector3 direction;
    private void Update()
    {
        transform.position += -direction * speed * Time.deltaTime;
    }
}
