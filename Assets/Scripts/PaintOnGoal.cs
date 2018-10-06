using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintOnGoal : MonoBehaviour
{
    [HideInInspector]
    public bool reset = false;

    private Color previousColor;
    private Color teamColor;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        previousColor = sprite.color;
    }

    public IEnumerator Paint(Color color)
    {
        // get H and V from team who scored, but keep old S
        float H, S, V, newH, newS, newV;
        Color.RGBToHSV(previousColor, out H, out S, out V);
        Color.RGBToHSV(color, out newH, out newS, out newV);


        if(S < 10)
            sprite.color = Color.HSVToRGB(newH, newS, newV);
        else
            sprite.color = Color.HSVToRGB(newH, S, newV);

        while(!reset)
            yield return 0;

        reset = false;
        sprite.color = previousColor;
    }
}
