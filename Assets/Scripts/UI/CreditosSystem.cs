using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditosSystem : MonoBehaviour
{
    public GameObject video;
    public GameObject finJuego;

    // Start is called before the first frame update
    void Start()
    {
        video.SetActive(false);
        finJuego.SetActive(false);
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        video.SetActive(true);
        yield return new WaitForSeconds(30f);
        video.SetActive(false);
        finJuego.SetActive(true);
    }


    public void volverAlMenuPrincipal()
    {
        GameManager.instance.LoadScene("MainMenu");
    }

    public void Exit()
    {
        GameManager.instance.QuitGame();
    }
}
