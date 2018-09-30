using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thrust;
    public Camera c;

    private Rigidbody2D rb2d;


	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();

        //Camera c = GetComponent<Camera>();
        Debug.Log("aspect: " + c.aspect);
    }

    void FixedUpdate ()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        rb2d.AddForce(transform.up * vertical * thrust);
        rb2d.AddTorque(-horizontal);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
