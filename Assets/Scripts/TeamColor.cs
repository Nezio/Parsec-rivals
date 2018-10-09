using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamColor : MonoBehaviour
{ // attach this script to to elements that should be colored based on what team they belog to
    
    [Range(1, 2)]
    public int team;
    [Tooltip("If saturation is left at 0 it won't be changed")]
    [Range(0, 100)]
    public int saturation = 0;

    [HideInInspector]
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
        Outline outline = gameObject.GetComponent<Outline>();

        // saturation
        if(saturation != 0)
        {
            teamColors[0] = Desaturate(teamColors[0], saturation);
            teamColors[1] = Desaturate(teamColors[1], saturation);
        }
        

        if (sprite != null)
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
        if(outline != null)
        {
            outline.effectColor = new Color(teamColors[team].r, teamColors[team].g, teamColors[team].b, outline.effectColor.a);
        }
        
    }

    private Color Desaturate(Color color, float amount)
    {
        if (amount < 0)
            amount = 0;
        if (amount > 100)
            amount = 100;

        amount = amount / 100;

        float H, S, V;

        Color.RGBToHSV(color, out H, out S, out V);
        S = S * amount;

        return Color.HSVToRGB(H, S, V);
    }

}
