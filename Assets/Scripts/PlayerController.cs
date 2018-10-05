using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thrust;
    public float yawThrust;
    public float fireRate;

    public string keyFire = "LeftShift";
    public string keyForward = "W";
    public string keyBackward = "S";
    public string keyLeft = "A";
    public string keyRight = "D";

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public GameObject ball;
    public bool collideWithBall;
    public GameManager gameManager;


    private Rigidbody2D rb;
    private float nextFire = 0;
    private Animator animtr;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(ball.GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>(), !collideWithBall);
        animtr = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        // Ctrl key doesn't work with some movement keys at the same time - only in Unity editor; build works
        if (Input.GetKey(Tools.GetKeycode(keyFire)) && nextFire < Time.time && Time.timeScale != 0)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }

    }

    private void FixedUpdate()
    {
        //float vertical = Input.GetAxis("Vertical");
        //float horizontal = Input.GetAxis("Horizontal");

        //rb.AddForce(transform.up * vertical * thrust);
        //rb.AddTorque(-horizontal);


        if (Input.GetKey(Tools.GetKeycode(keyForward)))
        { // forward
            rb.AddForce(transform.up * thrust);

            // enable boost animation
            animtr.SetBool("goingForward", true);
        }
        else
        {
            // disableboost animation
            animtr.SetBool("goingForward", false);
        }
            
        if (Input.GetKey(Tools.GetKeycode(keyBackward)))
        { // backward
            rb.AddForce(transform.up * thrust * -0.5f);
        }
            
        if (Input.GetKey(Tools.GetKeycode(keyLeft)))
        { // left
            rb.AddTorque(yawThrust);
        }
            
        if (Input.GetKey(Tools.GetKeycode(keyRight)))
        { // right
            rb.AddTorque(-yawThrust);
        }
            

    }
}
