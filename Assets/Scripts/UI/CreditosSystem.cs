using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditosSystem : MonoBehaviour
{
    public GameObject texto;
    public GameObject button;
    public GameObject button2;

    // Start is called before the first frame update
    void Start()
    {
        texto.SetActive(false);
        button.SetActive(false);
        button2.SetActive(false);
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        texto.SetActive(true);
        yield return new WaitForSeconds(50f);
        texto.SetActive(false);
        button.SetActive(true);
        button2.SetActive(true);
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
