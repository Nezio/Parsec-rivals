using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public Transform target = null;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        try
        {
            target = GameObject.FindGameObjectWithTag("Ball").transform;
        }
        catch
        {
            target = null;
        }

        
    }

    private void FixedUpdate()
    {
        //Debug.Log(target);
        if(target != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.velocity = transform.up * speed;
        }
        else
        {
            rb.velocity = transform.up * speed;
        }
        
    }

}
