using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionCheck : MonoBehaviour
{
    public GameObject gameController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collided with goal1 -> team 2 scored
        if (collision.gameObject.tag == "Goal1")
        {
            gameController.GetComponent<GameController>().Goal(2);
        }

        // collided with goal2 -> team 1 scored
        if (collision.gameObject.tag == "Goal2")
        {
            gameController.GetComponent<GameController>().Goal(1);
        }
    }
}
