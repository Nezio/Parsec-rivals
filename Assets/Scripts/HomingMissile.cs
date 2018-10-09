using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 200f;
    [Tooltip("Player must be looking at the ball head-on or within this angle for missile curving to work")]
    [Range(0, 90)]
    public int operationAngle;

    public Transform target = null;

    [HideInInspector]
    public GameObject player;

    private Rigidbody2D rb;
    private GameObject ball;
    private float playerFacing;     // used to detect if player is facing the ball and at what angle

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        ball = GameObject.FindGameObjectWithTag("Ball");

        try
        {
            target = GameObject.FindGameObjectWithTag("Ball").transform;
        }
        catch
        {
            target = null;
        }

        if (ball != null)
        {
            // returns 1 if player is looking straight at the ball, -1 if looking away, and 0 if looking at either side wiht 90 degres to the ball
            playerFacing = Vector3.Dot(player.transform.up, (ball.transform.position - player.transform.position).normalized);
            if (playerFacing < 0 || playerFacing < 1 - ((float)operationAngle / 100))
                playerFacing = 0;
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

            rb.angularVelocity = -rotateAmount * rotateSpeed * playerFacing;
            rb.velocity = transform.up * speed;
        }
        else
        {
            rb.velocity = transform.up * speed;
        }
        
    }

}
