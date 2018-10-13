using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIEventHandlerMenu : MonoBehaviour
{ // used to respond to UI events (like button clicks) in main and other menus

    public GameObject mapSelector;
    public Image mapSelectButtonImage;

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
        try
        {
            SceneManager.LoadScene(name);
        }
        catch
        {
            Debug.Log("Could not load scene: '" + name + "'!");
        }
        
    }

    public void SetMapToLoad(string map)
    { // buttons in map selector screen call this

        MatchSettings.mapToLoad = map;  // set map to load; game manager reads this in his Awake

        // set image of selected map to be visible in lobby
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        mapSelectButtonImage.sprite = clickedButton.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().sprite;
        
        mapSelector.SetActive(false);   // disable map selector screen after selecting a map
        
    }

    public void ShowMapSelector()
    {
        mapSelector.SetActive(true);
        //Debug.Log(GameObject.FindGameObjectWithTag("MapSelector").name;
    }
    
}
