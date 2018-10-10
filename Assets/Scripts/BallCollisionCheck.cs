using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionCheck : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject particleExplosionPrefab;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collided with goal1 -> team 2 scored
        if (collision.gameObject.tag == "Goal1")
        {
            gameManager.ScoreGoal(2);

            Goal();
        }

        // collided with goal2 -> team 1 scored
        if (collision.gameObject.tag == "Goal2")
        {
            gameManager.ScoreGoal(1);

            Goal();
        }

        
    }

    private void Goal()
    {
        audioManager.PlayOneShot("Goal");

        Instantiate(particleExplosionPrefab, gameObject.transform.position, gameObject.transform.rotation);

        gameObject.SetActive(false);
    }

}
