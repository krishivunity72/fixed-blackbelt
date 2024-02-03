using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed;
    public float xBoundlow = -68.5f;
    public float yBoundhigh = 182.5f;
    public float xBoundhigh = 60.4f;
    public float yBoundlow = -1.5f;


    private Vector3 direction;

    void Start()
    {
        SetRandomDirection();
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "xsides")
        {
           direction = new Vector3(-direction.x, direction.y, direction.z);

        }
        if (collision.gameObject.tag == "ysides")
        {
            direction = new Vector3(direction.x, -direction.y, direction.z);
        }
    
    }

    public void SetRandomDirection()
    {
        direction = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            0f
        ).normalized;
    }
}