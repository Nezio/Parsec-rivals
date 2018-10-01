using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionCheck : MonoBehaviour
{
    public float ballHitForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);

        // if bullet collides with the ball add force to the ball
        if(collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * ballHitForce);
        }

        // if bullet collides with player ignore collision (don't destroy bullet)
        if(collision.gameObject.tag == "Player")
        {
            return;
        }


        Destroy(gameObject);
    }

}
