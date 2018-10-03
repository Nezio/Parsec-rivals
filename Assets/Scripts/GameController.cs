using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text team1ScoreText;
    public Text team2ScoreText;
    public GameObject Ball;
    [Tooltip("Reference to a game object that has MatchTimer script attached.")]
    public GameObject timeText;
    public GameObject player1;
    public GameObject player2;
    public GameObject countdown;

    private int team1Score = 0;
    private int team2Score = 0;
    private GameObject ballSpawnPoint;
    private GameObject[] playerSpawnPoints;

    private void Start()
    {
        ballSpawnPoint = GameObject.FindGameObjectWithTag("BallSpawnPoint");
        playerSpawnPoints = GameObject.FindGameObjectsWithTag("PlayerSpawnPoint");

        StartRound();

    }

    private void StartRound()
    {
        PositionPlayers();

        // position ball
        Ball.transform.SetPositionAndRotation(ballSpawnPoint.transform.position, ballSpawnPoint.transform.rotation);

        // clear playing field (of bullets, powerups, etc.)

        // freeze players (and other moving objects/events/timers) - time scale?
        // countdown
        // resume timer
        StartCoroutine(Countdown());
   
    }

    private void PositionPlayers()
    {
        List<int> usedSpawns = new List<int>();

        int numberOfPlayers = 2;
        List<GameObject> team1Players = new List<GameObject>();
        List<GameObject> team2Players = new List<GameObject>();
        team1Players.Add(player1);
        team2Players.Add(player2);

        // TODO:
        // instantiate players on start off screen in 2 arrays (one for both teams); this is possible after key rebinding implementation
        
        // set spawn points to all players in team1 and mirror to team2
        for (int i = 0; i < numberOfPlayers / 2; i++)
        {
            // select unoccupied spawn point
            int spawnIndex;
            do
            {
                spawnIndex = Random.Range(0, playerSpawnPoints.Length);
            }
            while (usedSpawns.Contains(spawnIndex));
            usedSpawns.Add(spawnIndex);

            // set spawn points to team1
            team1Players[i].transform.SetPositionAndRotation
            (
                playerSpawnPoints[spawnIndex].transform.position,
                playerSpawnPoints[spawnIndex].transform.rotation
            );

            // mirror and set spawns for team2
            Vector3 mirroredPosition = new Vector3
            (
                -playerSpawnPoints[spawnIndex].transform.position.x,
                -playerSpawnPoints[spawnIndex].transform.position.y,
                0
            );
            Quaternion mirroredRotation = Quaternion.Euler(new Vector3(0, 0, playerSpawnPoints[spawnIndex].transform.localEulerAngles.z + 180));
            team2Players[i].transform.SetPositionAndRotation(mirroredPosition, mirroredRotation);
            
        }
    }
    
    public void Goal(int teamWhoScored)
    {   // goal has been detected
        // this function is called from BallCollisionCheck when ball detects a goal
        
        UpdateScores(teamWhoScored);

        // pause timer
        timeText.GetComponent<MatchTimer>().pauseTimer = true;

        // score animations and slowdown

        // start new round
        StartRound();
    }

    private void UpdateScores(int teamWhoScored)
    {
        if(teamWhoScored == 1)
        {
            team1Score++;
        }
        else if(teamWhoScored == 2)
        {
            team2Score++;
        }

        // update score text
        team1ScoreText.text = team1Score.ToString();
        team2ScoreText.text = team2Score.ToString();
    }

    IEnumerator Countdown()
    {
        Time.timeScale = 0;
        countdown.SetActive(true);

        float pauseTime = Time.realtimeSinceStartup + 2f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;


        //animation.Play("die");
        //yield WaitForSeconds(animation["die"].length);
        //Destroy(this.gameObject); //destroys the object after animation ended

        // yield return new WaitForSeconds(2);

        Time.timeScale = 1;
        countdown.SetActive(false);
        timeText.GetComponent<MatchTimer>().pauseTimer = false;
    }



}
