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
    public MatchTimer matchTimer;
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
        ResetPlayers();

        // reset ball position and velocity
        Ball.transform.SetPositionAndRotation(ballSpawnPoint.transform.position, ballSpawnPoint.transform.rotation);
        Ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        // clean up playing field (of bullets, powerups, etc.)
        CleanUpField();

        // pause game, play countdown animation and unpause game
        StartCoroutine(Countdown());
   
    }

    private void ResetPlayers()
    { // resets player position and velocity
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


            // reset velocity
            team1Players[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            team2Players[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
    
    public void Goal(int teamWhoScored)
    {   // goal has been detected
        // this function is called from BallCollisionCheck when ball detects a goal
        
        UpdateScores(teamWhoScored);

        // pause timer only
        matchTimer.pauseTimer = true;

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

    public void PauseGame()
    {
        Time.timeScale = 0;
        matchTimer.pauseTimer = true;     // just in case
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;             // unpause game
        matchTimer.pauseTimer = false;     // unpause timer (timer starts paused to prevent 04:59 on start)
    }

    IEnumerator Countdown()
    { // pause game, play countdown animation and unpause game
        countdown.SetActive(true);      // enable animation gameobject
        PauseGame();             // pause game (animation won't stop because it's using unscaled time)
        
        Animator anmtr = countdown.GetComponent<Animator>();    // get animation length
        var animLength = anmtr.GetCurrentAnimatorStateInfo(0).length;
        
        float pauseTime = Time.realtimeSinceStartup + animLength;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;

        countdown.SetActive(false);     // disable animation gameobject
        UnpauseGame();      // unneeded, but just in case; animation unpauses game
    }

    private void CleanUpField()
    {
        // clean up bullets
        foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            Destroy(bullet);
        }
    }

    public void ShowScoresScreen()
    {

    }

}
