using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// used to move bullets
public class MoveForward : MonoBehaviour
{
    public float speed;

    // Use this for initialization
    void Start ()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }
	
}
