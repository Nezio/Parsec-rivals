using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEventHandlerGame : MonoBehaviour
{ // responds to UI events that happen in-match and can't(or wouldn't make sense to) be handled by UIEventHandlerMenu
    
    public GameManager gameManager;
    public GameObject pauseScreen;
    public UIController UICtrl;
    
    public void Resume()
    {
        pauseScreen.SetActive(false);
        gameManager.UnpauseGame();
        Time.timeScale = UICtrl.previousTimeScale;
    }
}
