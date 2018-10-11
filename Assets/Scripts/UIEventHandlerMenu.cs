using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEventHandlerMenu : MonoBehaviour
{ // used to respond to UI events (like button clicks) in main and other menus
    
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
    
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
