using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickablePuzzleLevel : MonoBehaviour
{
    public GameObject obj_selection;
    public GameObject obj_material;
    public string folderPath = "Scenes/Puzzles/Puzzle_";
    public string puzzleNumber;
    public bool isUnlocked;

    private ClickableWorlLevel cWL;
    private Renderer objTextureRender;

    private void Start()
    {
        objTextureRender = obj_material.GetComponent<Renderer>();
        cWL = this.gameObject.GetComponentInParent<ClickableWorlLevel>();
        obj_selection.SetActive(false);
        isUnlocked = PlayerPrefs.GetInt("puzzle_" + puzzleNumber) == 1 ? true : false;
        if (!isUnlocked)
        {
            Darken(65);
        }
    }

    public void OnMouseEnter()
    {
        if (!GameManager.instance.isPause() && cWL.getIsSelected() && isUnlocked)
        {
            obj_selection.SetActive(true);
        }
    }

    public void OnMouseExit()
    {
        if (!GameManager.instance.isPause() && cWL.getIsSelected() && isUnlocked)
        {
            obj_selection.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (!GameManager.instance.isPause() && cWL.getIsSelected() && isUnlocked)
        {
            //selected = true;
            //var mp = mapManager.GetComponent<MapManager>();
            //mp.goToLevel(levelNumber);
            Debug.Log("Al puzzle " + folderPath + puzzleNumber + "!!");
            GameManager.instance.LoadScene(folderPath + puzzleNumber);
        }
    }
    public void Darken(float percent)
    {
        percent = Mathf.Clamp01(percent);
        objTextureRender.material.color = new Color (objTextureRender.material.color.r * (1 - percent), objTextureRender.material.color.g * (1 - percent), objTextureRender.material.color.b * (1 - percent), objTextureRender.material.color.a);
    }
}
