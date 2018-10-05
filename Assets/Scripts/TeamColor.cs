using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamColor : MonoBehaviour
{ // attach this script to to elements that should be colored based on what team they belog to
    
    [Tooltip("Team 1 or team 2")]
    public int team;

    public Color[] teamColors = new Color[2];

    private void Start()
    {
        team--;

        teamColors[0] = Tools.Color0to1(0, 84, 255, 255);
        teamColors[1] = Tools.Color0to1(255, 128, 0, 255);
        
        // debug colors
        //teamColors[0] = Tools.Color0to1(0, 0, 255, 255);
        //teamColors[1] = Tools.Color0to1(255, 0, 0, 255);

        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        Image image = gameObject.GetComponent<Image>();
        Text text = gameObject.GetComponent<Text>();

        if(sprite != null)
        {
            sprite.color = teamColors[team];
        }
        if(image != null)
        {
            image.color = teamColors[team];
        }
        if(text != null)
        {
            text.color = teamColors[team];
        }
        
    }

}
