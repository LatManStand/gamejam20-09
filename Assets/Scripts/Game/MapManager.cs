using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    public bool starTranstion;
    public GameObject MainCamera;
    public GameObject transion1;

    // Start is called before the first frame update
    void Start()
    {
        starTranstion = false;
        MainCamera.SetActive(true);
        transion1.SetActive(false);
    }

    public void goToLevel(int levelNumber)
    {
        starTranstion = true;
        Debug.Log("Se fue al nivel: " + levelNumber);
        activateTransition(levelNumber);
    }

    private void activateTransition (int levelNumber)
    {
        MainCamera.SetActive(false);
        switch(levelNumber)
        {
            case 0:
                transion1.SetActive(true);
                break;
        }
    }
}
