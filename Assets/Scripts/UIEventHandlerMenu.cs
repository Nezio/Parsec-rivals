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

    private string mapToLoad = "Map1";

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
        mapToLoad = map;
        Debug.Log(map);

        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        mapSelectButtonImage.sprite = clickedButton.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().sprite;
        
        mapSelector.SetActive(false);
    }

    public void LoadSetMap()
    { // start button calls this
        LoadScene(mapToLoad);
    }

    public void ShowMapSelector()
    {
        mapSelector.SetActive(true);
        //Debug.Log(GameObject.FindGameObjectWithTag("MapSelector").name;
    }
    
}
