using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public Transform enemy;
    public Transform start;
    public Transform end;

    int dir = 1;
    public float speed;

    public float shootingSpeed;
    private float bulletSpeed;

    public GameObject bulletPrefab;

    private void Start()
    {
        bulletSpeed = speed * 3;
        StartCoroutine(Shoot());
    }
    private void Update()
    {
        Vector2 target = CurrentMovementTarget();

        enemy.position = Vector2.MoveTowards(enemy.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)enemy.position).magnitude;

        if (distance <= 0.1f)
        {
            dir *= -1;
            enemy.transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    Vector2 CurrentMovementTarget()
    {
        if (dir == 1)
        {
            return start.position;
        }
        else
        {
            return end.position;

        }

    }

    private void OnDrawGizmos()
    {
        if (enemy != null && start != null && end != null)
        {
            Gizmos.DrawLine(enemy.position, start.position);
            Gizmos.DrawLine(enemy.position, end.position);

        }
    }

    private IEnumerator Shoot()
    {   
        while (true)
        {
            yield return new WaitForSeconds(shootingSpeed);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Projectile>().direction = transform.right.normalized;
        }
    }
    
}