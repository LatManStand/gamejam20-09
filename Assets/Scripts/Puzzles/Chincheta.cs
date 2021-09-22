using UnityEngine;

public class Chincheta : MonoBehaviour
{
    public bool puedeTablon;
    public bool estaLibre = true;

    private void OnMouseEnter()
    {
        if (estaLibre)
        {
            MouseController.instance.mouseOver = this;
            MouseController.instance.puedeTablon = puedeTablon;
        }

    }

    private void OnMouseExit()
    {
        MouseController.instance.mouseOver = null;
    }
}
