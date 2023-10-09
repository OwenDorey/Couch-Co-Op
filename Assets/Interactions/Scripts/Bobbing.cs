using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    private Vector3 bottom;
    private Vector3 top;

    public float offset = 0.1f;
    public float moveSpeed = 0.2f;

    private Vector3 destination;

    void Start()
    {
        bottom = transform.position - new Vector3 (0, offset, 0);
        top = transform.position + new Vector3(0, offset, 0);
        transform.position = bottom;
    }

    void Update()
    {
        if (transform.position.y == bottom.y)
        {
            destination = top;
        }
        else if (transform.position.y == top.y)
        {
            destination = bottom;
        }

        transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
    }
}
