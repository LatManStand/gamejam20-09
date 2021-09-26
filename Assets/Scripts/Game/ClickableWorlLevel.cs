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

    public void GoBackToMenu ()
    {
        var mp = mapManager.GetComponent<MapManager>();
        obj_selection.SetActive(true);
        selected = false;
    }

    public void OnMouseEnter()
    {
        if(!GameManager.instance.isPause() && !selected)
        {
            obj_selection.SetActive(true);
        }
    }

    public void OnMouseExit()
    {
        if (!GameManager.instance.isPause() && !selected)
        {
            obj_selection.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (!GameManager.instance.isPause() && !selected)
        {
            selected = true;
            var mp = mapManager.GetComponent<MapManager>();
            obj_selection.SetActive(false);
            mp.goToLevel(levelNumber);
            this.gameObject.GetComponent<ClickableWorlLevel>().enabled = false;
        }
    }
}
