using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
