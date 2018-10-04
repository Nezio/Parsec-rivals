using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_UnpauseGame : MonoBehaviour
{
    public GameManager gameManager;

    public void AnimationUnpause()
    {
        gameManager.UnpauseGame();
    }
	
}
