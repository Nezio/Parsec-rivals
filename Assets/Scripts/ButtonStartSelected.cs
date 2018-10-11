using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStartSelected : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Button>().Select();
    }
}
