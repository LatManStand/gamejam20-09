using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    public void UI_GoBackToMap()
    {
        GameManager.instance.SaveData();
        GameManager.instance.LoadScene("Map");
    }
}
