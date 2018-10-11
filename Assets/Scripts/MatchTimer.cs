using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchTimer : MonoBehaviour
{
    public int matchLength = 5;         // how long doeas a match last (in minutes)
    public bool pauseTimer = false;
    public bool countUp = false;
    public GameManager gameManager;

    private float currentTimerTime;       // current time to display on timer (in seconds)
    private Text timerText;
    private int pastTimerSecond;
    private AudioManager audioManager;

    private void Start()
    {
        currentTimerTime = matchLength * 60;
        //currentTimerTime = 15;      // debug
        timerText = gameObject.GetComponent<Text>();
        pastTimerSecond = (int)currentTimerTime;
        audioManager = GameObject.FindObjectOfType<AudioManager>();

        UpdateTimeText();
        
    }

    private void Update()
    {
        if(!pauseTimer)
        {
            if(countUp)
            {
                currentTimerTime += Time.deltaTime;
            }
            else
            {
                currentTimerTime -= Time.deltaTime;
                if (currentTimerTime < 0)
                    currentTimerTime = 0;
            }
            

            // avoid unnecessary gui draws
            if(pastTimerSecond != (int)currentTimerTime)
            {
                //Debug.Log("past:" + pastTimerSecond + "now: " + currentTimerTime);
                if ((int)currentTimerTime == 0)
                {
                    if (gameManager.GetScores()[0] == gameManager.GetScores()[1])
                        gameManager.EnterOvertime();
                    else
                        gameManager.EndMatch();
                }
                

                pastTimerSecond = (int)currentTimerTime;
                UpdateTimeText();
            }
            
            
                
        }
        
    }

    // reads from currentTimerTime, formats and diplays
    private void UpdateTimeText()
    {
        int minutes = (int)(currentTimerTime / 60);
        int seconds = (int)(currentTimerTime % 60);

        string minutesText;
        string secondsText;

        if (minutes < 10)
            minutesText = "0" + minutes;
        else
            minutesText = minutes.ToString();

        if (seconds < 10)
            secondsText = "0" + seconds;
        else
            secondsText = seconds.ToString();

        timerText.text = minutesText + ":" + secondsText;

        if(currentTimerTime<11 && !gameManager.overtime)
        {
            timerText.color = Tools.Color0to1(255, 88, 0);
            audioManager.PlayOneShot("BeepCountdown");
        }
        else
        {
            timerText.color = Tools.Color0to1(255, 255, 255);
        }
    }
}
