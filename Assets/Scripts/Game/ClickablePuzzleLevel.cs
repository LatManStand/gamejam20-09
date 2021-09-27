using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickablePuzzleLevel : MonoBehaviour
{
    public GameObject obj_selection;
    public GameObject obj_material;
    public string puzzleLevel;
    public string puzzleNumber;
    public bool isUnlocked;

    private string folderPath = "Scenes/Puzzles/";
    private ClickableWorlLevel cWL;
    private Renderer objTextureRender;
    private Vector3 initialSize;

    private void Start()
    {
        initialSize = this.gameObject.transform.localScale;
        objTextureRender = obj_material.GetComponent<Renderer>();
        cWL = this.gameObject.GetComponentInParent<ClickableWorlLevel>();
        obj_selection.SetActive(false);
        isUnlocked = PlayerPrefs.GetInt("Puzzle_" + puzzleNumber) == 1 ? true : false;
        if (!isUnlocked)
        {
            Darken(0.5f);
        }
    }

    public void OnMouseEnter()
    {
        if (!GameManager.instance.isPause() && cWL.getIsSelected() && isUnlocked)
        {
            Debug.Log("eh");
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
            puzzleNumber = puzzleNumber[0] + "." + puzzleNumber[2];
            Debug.Log("Al puzzle " + folderPath + puzzleNumber + "!!");
            GameManager.instance.LoadScene(folderPath + "Level_" + puzzleLevel + "/Puzzle_" + puzzleNumber);
        }
    }
    public void Darken(float percent)
    {
        percent = Mathf.Clamp01(percent);
        List<Material> listMaterials = new List<Material>();
        objTextureRender.GetMaterials(listMaterials);

        foreach( var material in listMaterials)
        {
            material.color = new Color(objTextureRender.material.color.r * (1 - percent), objTextureRender.material.color.g * (1 - percent), objTextureRender.material.color.b * (1 - percent), objTextureRender.material.color.a);
        }

        //objTextureRender.material.color = new Color (objTextureRender.material.color.r * (1 - percent), objTextureRender.material.color.g * (1 - percent), objTextureRender.material.color.b * (1 - percent), objTextureRender.material.color.a);
        ////objTextureRender.GetMaterials(listMaterials); material.color = new Color (objTextureRender.material.color.r * (1 - percent), objTextureRender.material.color.g * (1 - percent), objTextureRender.material.color.b * (1 - percent), objTextureRender.material.color.a);
        //objTextureRender.material.color = new Color (objTextureRender.material.color.r * (1 - percent), objTextureRender.material.color.g * (1 - percent), objTextureRender.material.color.b * (1 - percent), objTextureRender.material.color.a);
    }
}
