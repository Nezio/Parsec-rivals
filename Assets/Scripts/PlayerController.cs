using System;
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
    private AudioManager audioManager;
    private string playerID;
    private string boostSound;

    private bool forward = false;
    private bool backward = false;
    private bool left = false;
    private bool right = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetPlayerBallCollision();
        animtr = gameObject.GetComponent<Animator>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        playerID = gameObject.name.Substring(8, 1);
        boostSound = "BoostP" + playerID;
    }

    public void SetPlayerBallCollision()
    {
        Physics2D.IgnoreCollision(ball.GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>(), !collideWithBall);
    }

    private void Update()
    {
        // Ctrl key doesn't work with some movement keys at the same time - only in Unity editor; build works
        if (Input.GetKey(Tools.GetKeycode(keyFire)) && nextFire < Time.time && Time.timeScale != 0)
        { // fire
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<HomingMissile>().player = gameObject;   // set reference to this player in instanced bullet
            audioManager.PlayOneShot("Shoot");
        }

        if (Input.GetKey(Tools.GetKeycode(keyForward)))
        { // forward
            forward = true;

            animtr.SetBool("goingForward", true);       // enable boost animation

            if(!audioManager.IsPlaying(boostSound))     // play audio
                audioManager.Play(boostSound);          // TODO?: move audio to player prefab
        }
        else
        {
            forward = false;

            animtr.SetBool("goingForward", false);  // disable boost animation
            
        }

        if(Input.GetKeyUp(Tools.GetKeycode(keyForward)))
        {
            StartCoroutine(audioManager.FadeOutStop(boostSound, 0.1f));     // stop audio with fade to avoid sound poping on cut-off
        }

        if (Input.GetKey(Tools.GetKeycode(keyBackward)))
        { // backward
            backward = true;
        }
        else
        {
            backward = false;
        }

        if (Input.GetKey(Tools.GetKeycode(keyLeft)))
        { // left
            left = true;
        }
        else
        {
            left = false;
        }

        if (Input.GetKey(Tools.GetKeycode(keyRight)))
        { // right
            right = true;
        }
        else
        {
            right = false;
        }
    }

    private void FixedUpdate()
    {
        //float vertical = Input.GetAxis("Vertical");
        //float horizontal = Input.GetAxis("Horizontal");

        //rb.AddForce(transform.up * vertical * thrust);
        //rb.AddTorque(-horizontal);
        
        if (forward)
        { // forward
            rb.AddForce(transform.up * thrust);
        }

        if (backward)
        { // backward
            rb.AddForce(transform.up * thrust * -0.5f);
        }
            
        if (left)
        { // left
            rb.AddTorque(yawThrust);
        }
            
        if (right)
        { // right
            rb.AddTorque(-yawThrust);
        }
            

    }
}
