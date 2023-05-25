using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.0f;

    private Vector3 currentTarget;

    private void Start()
    {
        currentTarget = endPoint.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        if (transform.position == endPoint.position)
        {
            currentTarget = startPoint.position;
        }
        else if (transform.position == startPoint.position)
        {
            currentTarget = endPoint.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
