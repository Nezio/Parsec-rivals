using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEventHandler : MonoBehaviour
{ // used to respond to UI events (like button clicks)
    public GameManager gameManager;
    public GameObject pauseScreen;
    public UIController UICtrl;

    public void ExitGame()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        gameManager.UnpauseGame();
        Time.timeScale = UICtrl.previousTimeScale;
    }
}
