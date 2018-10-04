using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionCheck : MonoBehaviour
{
    public GameObject gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collided with goal1 -> team 2 scored
        if (collision.gameObject.tag == "Goal1")
        {
            gameManager.GetComponent<GameManager>().Goal(2);
        }

        // collided with goal2 -> team 1 scored
        if (collision.gameObject.tag == "Goal2")
        {
            gameManager.GetComponent<GameManager>().Goal(1);
        }
    }
}
