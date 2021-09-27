using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuPrincipalScript : MonoBehaviour
{
    public GameObject menu1;
    //public GameObject video;
    //public GameObject backgroud;

    private void Start()
    {
        OpenMenu1();
    }

    private void OpenMenu1()
    {
        menu1.SetActive(true);
        //backgroud.SetActive(true);
        //video.SetActive(false);
    }

    private void OpenMenu2()
    {
        menu1.SetActive(false);
        //backgroud.SetActive(true);
        //video.SetActive(false);
    }

    //Este método lo usaremos para meter un vídeo o una animación.
    // Ya vermeos qué hacemos.
    //IEnumerator StartGameAnimation()
    //{
    //    menu1.SetActive(false);
    //    //video.SetActive(true);
    //    //backgroud.SetActive(false);
    //    yield return new WaitForSeconds(3.0f);
    //    GameManager.instance.LoadScene("World");
    //}

    // ---------------------------------- Métodos para el MENU 1 ---------------------------------- 
    public void StartGame()
    {
        //StartCoroutine(StartGameAnimation());

        GameManager.instance.StartGame();
    }

    public void ContinueGame()
    {
        GameManager.instance.LoadScene("Map");
    }

    public void GoToCredits()
    {
        GameManager.instance.LoadScene("Credits");
    }
    
    public void GoToOptions()
    {
        OpenMenu2();
    }

    // ---------------------------------- Métodos para el MENU 2 ---------------------------------- 
    public void GoBackToInitalMenu()
    {
        OpenMenu1();
    }
}
