using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimationMenu : MonoBehaviour
{
    public GameObject barra1;
    public GameObject barra2;

    private void Start()
    {
        barra1.SetActive(false);
        barra2.SetActive(false);
    }

    public void OnMouseEnter()
    {
        barra1.SetActive(true);
        barra2.SetActive(true);
    }

    public void OnMouseExit()
    {
        barra1.SetActive(false);
        barra2.SetActive(false);
    }
}
