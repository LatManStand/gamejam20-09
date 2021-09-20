using UnityEngine;

public class Chincheta : MonoBehaviour
{
    private void OnMouseEnter()
    {
        MouseController.instance.mouseOver = this;
    }

    private void OnMouseExit()
    {
        MouseController.instance.mouseOver = null;
    }
}
