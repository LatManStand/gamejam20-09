using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableWorlLevel : MonoBehaviour
{
    public GameObject obj_selection;
    public GameObject mapManager;
    public bool selected;
    public int levelNumber;

    private GameObject obj;


    private void Start()
    {
        obj = this.gameObject;
        obj_selection.SetActive(false);
        selected = false;
    }

    public bool getIsSelected()
    {
        return selected;
    }

    public void OnMouseEnter()
    {
        if(!selected)
        {
            obj_selection.SetActive(true);
        }
    }

    public void OnMouseExit()
    {
        if (!selected)
        {
            obj_selection.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (!selected)
        {
            selected = true;
            var mp = mapManager.GetComponent<MapManager>();
            obj_selection.SetActive(false);
            mp.goToLevel(levelNumber);
            this.gameObject.GetComponent<ClickableWorlLevel>().enabled = false;
        }
    }
}
