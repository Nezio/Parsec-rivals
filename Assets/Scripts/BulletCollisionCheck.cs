using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionCheck : MonoBehaviour
{
    public float ballHitForce;
    public GameObject particleExplosionPrefab;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);

        // if bullet collides with the ball add force to the ball
        if(collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * ballHitForce);

            audioManager.Play("BulletExplode2");    // play audio
        }

        // if bullet collides with player ignore collision (don't destroy bullet)
        if(collision.gameObject.tag == "Player")
        {
            return;
        }

        // if bullet collides with goal ignore collision (don't destroy bullet)
        if(collision.gameObject.tag.Contains("Goal"))
        {
            return;
        }


        // play particle explosion
        Instantiate(particleExplosionPrefab, gameObject.transform.position, gameObject.transform.rotation);

        // play audio
        //int explodeSoundIndex = Random.Range(1, 3);
        audioManager.Play("BulletExplode1");


        Destroy(gameObject);
    }

}
