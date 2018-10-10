using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_UnpauseGame : MonoBehaviour
{
    public GameManager gameManager;
    
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    public void AnimationUnpause()
    {
        gameManager.UnpauseGame();

        BeepGo();
    }
	
    public void Beep()
    {
        audioManager.PlayOneShot("Beep");
    }

    public void BeepGo()
    {
        audioManager.PlayOneShot("BeepGo");
    }
}
