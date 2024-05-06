using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script should be put on the camera GO
public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;
    private Transform toFollow;
    [SerializeField] private Bounds worldBounds; //the camera will only move within these bounds, and never move outside

    [Header("Bounds")]
    [SerializeField] private float followBoundX = 0.15f;
    [SerializeField] private float followBoundY = 0.05f;

    private float camHorizontalExtent;
    private float camVerticalExtent;

    private void Start()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        toFollow = GameObject.FindWithTag("Player").transform;
        camHorizontalExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
        camVerticalExtent = Camera.main.orthographicSize;

        RecenterCamera();
    }

    private void LateUpdate()
    {
        if (toFollow == null) return;
        //if (transform.position.x + camHorizontalExtent >= worldBounds.center.x  + worldBounds.extents.x)
        //return;

        Vector3 newPosition = CalculateFollowBounds();

        transform.position += new Vector3(newPosition.x, newPosition.y, 0);
    }

    private Vector3 CalculateFollowBounds()
    {
        Vector3 delta = Vector3.zero;
        //checks if we are inside the bounds on the x axis
        float deltaX = toFollow.position.x - transform.position.x;
        if (deltaX > followBoundX || deltaX < -followBoundX)
        {
            if (transform.position.x < toFollow.position.x)
            {
                delta.x = deltaX - followBoundX;
            }
            else
            {
                delta.x = deltaX + followBoundX;
            }
        }
        if (!ToFollowInXBounds())
            delta.x = 0;

        //checks if we are inside the bounds on the y axis
        float deltaY = toFollow.position.y - transform.position.y;
        if (deltaY > followBoundY || deltaY < -followBoundY)
        {
            if (transform.position.y < toFollow.position.y)
            {
                delta.y = deltaY - followBoundY;
            }
            else
            {
                delta.y = deltaY + followBoundY;
            }
        }
        if (!ToFollowInYBounds())
            delta.y = 0;

        return delta;
    }

    public bool ToFollowInXBounds()
    {
        return toFollow.position.x + camHorizontalExtent <= worldBounds.center.x + worldBounds.extents.x && toFollow.position.x - camHorizontalExtent >= worldBounds.center.x - worldBounds.extents.x;
    }
    public bool ToFollowInYBounds()
    {
        return toFollow.position.y + camHorizontalExtent <= worldBounds.center.y + worldBounds.extents.y && toFollow.position.y - camHorizontalExtent >= worldBounds.center.y - worldBounds.extents.y;
    }

    public void RecenterCamera()
    {
        transform.position = new Vector3(toFollow.position.x, toFollow.position.y, transform.position.z);
        float x = transform.position.x > worldBounds.center.x ? worldBounds.center.x + worldBounds.extents.x - camHorizontalExtent : worldBounds.center.x - worldBounds.extents.x + camHorizontalExtent;
        float y = transform.position.y > worldBounds.center.y ? worldBounds.center.y + worldBounds.extents.y - camVerticalExtent : worldBounds.center.y - worldBounds.extents.y + camVerticalExtent;
        if (!ToFollowInXBounds())
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        if (!ToFollowInYBounds())
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(worldBounds.center, worldBounds.size);
    }
}
