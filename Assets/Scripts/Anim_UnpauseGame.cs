using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_UnpauseGame : MonoBehaviour
{
    public GameController gameController;

    public void AnimationUnpause()
    {
        gameController.UnpauseGame();
    }
	
}
