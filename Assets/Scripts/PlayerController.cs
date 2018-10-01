using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thrust;
    public float fireRate;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public bool collideWithBall;
    public GameObject ball;

    private Rigidbody2D rb;
    private float nextFire = 0;
    
    // Use this for initialization
    private void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

        Physics2D.IgnoreCollision(ball.GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>(), !collideWithBall);

    }

    private void Update()
    {
        // Ctrl key (fire1) doesn't work with some movement keys at the same time - only in Unity editor; build works
        if (Input.GetButton("Fire3") && nextFire < Time.time)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }

    }

    private void FixedUpdate ()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        rb.AddForce(transform.up * vertical * thrust);
        rb.AddTorque(-horizontal);

    }
    

}
