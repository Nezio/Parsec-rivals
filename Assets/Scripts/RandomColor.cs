using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public GameObject ship;
    public GameObject flame;

    List<Color> colors = new List<Color>();

    private void Start()
    {
        colors.Add(Tools.Color0to1(0, 84, 255));
        colors.Add(Tools.Color0to1(255, 128, 0));

        int cIndex = Random.Range(0, colors.Count);
        ship.GetComponent<SpriteRenderer>().color = colors[cIndex];

        Color flameColor = colors[cIndex];
        float H, S, V;
        Color.RGBToHSV(flameColor, out H, out S, out V);
        H -= 0.06f;
        flame.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(H, S, V);
    }
}
