using UnityEngine;


public class MovingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform start;
    public Transform end;

    int dir = 1;
    public float speed;

    private void Update()
    {
        Vector2 target = CurrentMovementTarget();

        platform.position = Vector2.MoveTowards(platform.position, target, speed * Time.deltaTime);
        
        float distance = (target - (Vector2)platform.position).magnitude;

        if (distance <= 0.1f)
            dir *= -1;
    }

    Vector2 CurrentMovementTarget()
    {
        if(dir == 1)
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
        if(platform!=null && start!=null && end != null)
        {
            Gizmos.DrawLine(platform.position, start.position);
            Gizmos.DrawLine(platform.position, end.position);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = platform.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
