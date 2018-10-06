using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionCheck : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collided with goal1 -> team 2 scored
        if (collision.gameObject.tag == "Goal1")
        {
            gameManager.ScoreGoal(2);

            gameObject.SetActive(false);
        }

        // collided with goal2 -> team 1 scored
        if (collision.gameObject.tag == "Goal2")
        {
            gameManager.ScoreGoal(1);

            gameObject.SetActive(false);
        }

        
    }
}
