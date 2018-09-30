using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thrust;

    private Rigidbody2D rb;


	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate ()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        rb.AddForce(transform.up * vertical * thrust);
        rb.AddTorque(-horizontal);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
