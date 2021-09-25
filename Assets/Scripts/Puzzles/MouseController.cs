using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public static MouseController instance;
    public Chincheta mouseOver;
    public Chincheta clickedChinche;
    public CuerdaPuente currentCuerda;
    public Tablon currentTablon;
    public List<CuerdaPuente> cuerdas;
    public List<Tablon> tablones;
    public GameObject cuerdaPrefab;
    public GameObject tablonPrefab;

    public bool puedeTablon;

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
        if (Input.GetMouseButtonDown(0) && mouseOver != null && currentCuerda == null && currentTablon == null)
        {
            clickedChinche = mouseOver;
            currentCuerda = Instantiate(cuerdaPrefab).GetComponent<CuerdaPuente>();
            currentCuerda.StartPoint = mouseOver.transform;
            currentCuerda.EndPoint = MouseToWorld.instance.transform;
            mouseOver.transform.root.GetComponent<Pieza>().cuerda = currentCuerda.tiraCuerdas;
        }
        else if (Input.GetMouseButtonUp(0) && mouseOver != null && clickedChinche != null && mouseOver != clickedChinche)
        {
            currentCuerda.EndPoint = mouseOver.transform;
            cuerdas.Add(currentCuerda);
            clickedChinche.GetComponent<Chincheta>().estaLibre = false;
            mouseOver.GetComponent<Chincheta>().estaLibre = false;
            mouseOver.transform.root.GetComponent<Pieza>().cuerda = currentCuerda.tiraCuerdas;
            clickedChinche = null;
            currentCuerda = null;
            mouseOver = null;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            clickedChinche = null;
            if (currentCuerda != null)
            {
                Destroy(currentCuerda.gameObject);
            }
        }
        else if (Input.GetMouseButtonDown(1) && mouseOver != null && currentCuerda == null && currentTablon == null && puedeTablon)
        {
            clickedChinche = mouseOver;
            currentTablon = Instantiate(tablonPrefab).GetComponent<Tablon>();
            currentTablon.SetPoints(mouseOver.transform, MouseToWorld.instance.transform);
        }
        else if (Input.GetMouseButtonUp(1) && mouseOver != null && clickedChinche != null && mouseOver != clickedChinche && puedeTablon)
        {

            currentTablon.SetEnd(mouseOver.transform);
            tablones.Add(currentTablon);
            clickedChinche.GetComponent<Chincheta>().estaLibre = false;
            mouseOver.GetComponent<Chincheta>().estaLibre = false;
            clickedChinche = null;
            currentTablon = null;
            mouseOver = null;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            clickedChinche = null;
            if (currentTablon != null)
            {
                Destroy(currentTablon.gameObject);
            }
        }


        if (Input.GetKeyDown(KeyCode.Escape)) // Input provisional
        {
            foreach (Tablon tablon in tablones)
            {
                tablon.startPoint.GetComponent<Chincheta>().estaLibre = true;
                tablon.endPoint.GetComponent<Chincheta>().estaLibre = true;
                Destroy(tablon.gameObject);
            }
            tablones.Clear();
            foreach (CuerdaPuente cuerda in cuerdas)
            {
                cuerda.StartPoint.GetComponent<Chincheta>().estaLibre = true;
                cuerda.EndPoint.GetComponent<Chincheta>().estaLibre = true;
                Destroy(cuerda.gameObject);
            }
            cuerdas.Clear();
        }
    }
}
