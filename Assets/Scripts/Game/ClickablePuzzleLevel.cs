using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickablePuzzleLevel : MonoBehaviour
{
    public GameObject obj_selection;
    public string folderPath = "Scenes/Puzzles/Puzzle_";
    public string puzzleNumber;

    private ClickableWorlLevel cWL;

    private void Start()
    {
        cWL = this.gameObject.GetComponentInParent<ClickableWorlLevel>();
        obj_selection.SetActive(false);
    }

    public void OnMouseEnter()
    {
        if (cWL.getIsSelected())
        {
            obj_selection.SetActive(true);
        }
    }

    public void OnMouseExit()
    {
        if (cWL.getIsSelected())
        {
            obj_selection.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        //selected = true;
        //var mp = mapManager.GetComponent<MapManager>();
        //mp.goToLevel(levelNumber);
        Debug.Log("Al puzzle " + folderPath + puzzleNumber + "!!");
        GameManager.instance.LoadScene(folderPath + puzzleNumber);
    }
}
