using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int lifeTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag !="Enemy") Destroy(gameObject);
    }
    [SerializeField] private float speed;
    [HideInInspector] public Vector3 direction;

    private void Start()
    {
        StartCoroutine(LifeSpan());
    }
    private void Update()
    {
        transform.position += -direction * speed * Time.deltaTime;
    }
    public IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
