using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 5.0f;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 10f;
    }
    private void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;
        if(transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
