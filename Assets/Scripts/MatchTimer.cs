using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchTimer : MonoBehaviour
{
    public int matchLength = 5;         // how long doeas a match last (in minutes)
    public bool pauseTimer = false;

    private float currentTimerTime;       // current time to display on timer (in seconds)
    private Text timerText;
    private int pastTimerSecond;

    // TODO: timer starts paused

    private void Start()
    {
        currentTimerTime = matchLength * 60;
        timerText = gameObject.GetComponent<Text>();
        pastTimerSecond = (int)currentTimerTime;

        UpdateTimeText();
        
    }

    private void Update()
    {
        if(!pauseTimer)
        {
            currentTimerTime -= Time.deltaTime;
            if (currentTimerTime < 0)
                currentTimerTime = 0;

            // avoid unnecessary gui draws
            if(pastTimerSecond!= (int)currentTimerTime)
            {
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
    }
}
