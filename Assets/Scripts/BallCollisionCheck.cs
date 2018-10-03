using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO:
        // on goal
            // inc score
            // enter cooldown (pause timer; play score animations; countdown to next round)
            // slowdown?
            // destroy ball (or move/reset pos, rot, velocity and hide)

        // on round start
            // start timer
            // reset ball
            // reset players


        // team 2 scored
        if (collision.gameObject.tag == "Goal1")
        {
            Debug.Log("g1");
        }

        // team 2 scored
        if (collision.gameObject.tag == "Goal2")
        {
            Debug.Log("g2");
        }
    }
}
