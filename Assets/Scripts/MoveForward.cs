using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// used to move bullets
public class MoveForward : MonoBehaviour
{

    private Rigidbody2D rb;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        rb.velocity = transform.up;
        Debug.Log("rb " + rb.velocity + " t " + transform.up);
	}
}
