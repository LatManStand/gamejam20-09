using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimationScript : MonoBehaviour
{
    public Text text;
    public int numTam = 5;

    public int tamOrigin;

    private void Start()
    {
        tamOrigin = text.fontSize;
    }

    public void OnMouseEnter()
    {
        text.fontSize = tamOrigin + numTam;
    }

    public void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        text.fontSize = tamOrigin;
    }
}
