using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimationMenu : MonoBehaviour
{
    public int slot;
    public GameObject barra1;
    public GameObject barra2;
    public Text texto1;

    private void Start()
    {
        if(GameManager.instance.language == "es")
        {
            texto1.text = "Nueva Partida";
        }
        else
        {
            texto1.text = "New slot";
        }

        barra1.SetActive(false);
        barra2.SetActive(false);
    }

    private void OnEnable()
    {
        if (GameManager.instance)
        {
            if (GameManager.instance.getIsCargarPartida())
            { 
                Debug.Log("IsCargarPartida");
                if (GameManager.instance.language == "es")
                {
                    Debug.Log("IsCargarPartida en es");
                    texto1.text = "Slot vacío";
                }
                else
                {
                    Debug.Log("IsCargarPartida en en");
                    texto1.text = "Empty slot";
                }
            }
            else
            {
                if (GameManager.instance.language == "es")
                {
                    texto1.text = "Nueva Partida";
                }
                else
                {
                    texto1.text = "New slot";
                }
            }
        }
    }

    public void ActionButton()
    {
        if (GameManager.instance.getIsCargarPartida())
        {
            if (GameManager.instance.existeSlotPartidaGuardada(slot) != 0)
            {
                GameManager.instance.LoadData(slot);
                GameManager.instance.LoadScene("World");
            }
        }
        else
        {
            GameManager.instance.StartGame(slot);
        }
    }

    public void OnMouseEnter()
    {
        barra1.SetActive(true);
        barra2.SetActive(true);
    }

    public void OnMouseExit()
    {
        barra1.SetActive(false);
        barra2.SetActive(false);
    }
}
