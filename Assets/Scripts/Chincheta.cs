using UnityEngine;

public class Chincheta : MonoBehaviour
{
    public bool puedeTablon;

    private void OnMouseEnter()
    {
        MouseController.instance.mouseOver = this;
        MouseController.instance.puedeTablon = puedeTablon;

    }

    private void OnMouseExit()
    {
        MouseController.instance.mouseOver = null;
    }
}
