using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public static MouseController instance;
    public Chincheta mouseOver;
    public Chincheta clickedChinche;
    public CuerdaPuente currentCuerda;
    public List<CuerdaPuente> cuerdas;
    public GameObject cuerdaPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            cuerdas = new List<CuerdaPuente>();
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
            currentCuerda = Instantiate(cuerdaPrefab).GetComponent<CuerdaPuente>();
            currentCuerda.StartPoint = mouseOver.transform;
            currentCuerda.EndPoint = MouseToWorld.instance.transform;
        }
        else if (Input.GetMouseButtonUp(0) && mouseOver != null && clickedChinche != null && mouseOver != clickedChinche)
        {
            Unioner.instance.Unir(clickedChinche, mouseOver);
            currentCuerda.EndPoint = mouseOver.transform;
            cuerdas.Add(currentCuerda);
        }
    }
}
