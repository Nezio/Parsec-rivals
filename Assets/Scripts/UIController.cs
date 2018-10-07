using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameManager gameManager;
    public UIEventHandler UIEventHndl;

    [HideInInspector]
    public float previousTimeScale = 1;
    
    private void Update()
    { // used to controll player input in regard to UI events

        if (Input.GetKeyDown(KeyCode.Escape) && gameManager.matchInProgress)
        {
            if(pauseScreen.activeSelf)
            { // already paused; unpause it
                UIEventHndl.Resume();
            }
            else
            { // pause
                previousTimeScale = Time.timeScale;
                gameManager.PauseGame();
                pauseScreen.SetActive(true);
            }
            

        }
    }
}
