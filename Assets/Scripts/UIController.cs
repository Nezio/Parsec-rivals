using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameManager gameManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameManager.countingDown)
        {
            if(pauseScreen.activeSelf)
            { // already paused; unpause it
                gameManager.UnpauseGame();
                pauseScreen.SetActive(false);
            }
            else
            { // pause
                gameManager.PauseGame();
                pauseScreen.SetActive(true);
            }
            

        }
    }
}
