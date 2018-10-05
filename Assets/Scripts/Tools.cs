using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools
{
    public static Color Color0to1(int r, int g, int b, int a)
    {
        return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
    }

    public static Color Color0to1(int r, int g, int b)
    {
        return new Color(r / 255f, g / 255f, b / 255f, 1f);
    }

    public static KeyCode GetKeycode(string key)
    {
        return (KeyCode)System.Enum.Parse(typeof(KeyCode), key);
    }
}
