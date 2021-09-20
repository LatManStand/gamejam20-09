using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public static MouseController instance;
    public Chincheta mouseOver;
    public Chincheta clickedChinche;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && mouseOver != null)
        {
            clickedChinche = mouseOver;
        }
        else if (Input.GetMouseButtonUp(0) && mouseOver != null && clickedChinche != null)
        {
            Unioner.instance.Unir(clickedChinche, mouseOver);
        }
    }
}
