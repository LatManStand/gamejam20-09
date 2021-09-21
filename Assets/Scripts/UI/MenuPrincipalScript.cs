using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuPrincipalScript : MonoBehaviour
{
    public GameObject menu1;
    public GameObject video;
    public GameObject backgroud;

    private void Start()
    {
        Menu1();
    }

    public void Menu1()
    {
        GameManager.instance.setIsCargarPartida(false);
        menu1.SetActive(true);
        backgroud.SetActive(true);
        video.SetActive(false);
    }

    public void EmpezarPartida()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        menu1.SetActive(false);
        video.SetActive(true);
        backgroud.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        GameManager.instance.LoadScene("Controls");
    }

    public void GoToCredits()
    {
        GameManager.instance.LoadScene("Creditos");
    }
    
    public void GoToOptions()
    {
        GameManager.instance.LoadScene("Options");
    }

    public void QuitGame()
    {
        GameManager.instance.QuitGame();
    }
}
