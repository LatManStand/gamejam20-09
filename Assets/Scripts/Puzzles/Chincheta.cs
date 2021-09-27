using UnityEngine;

public class Chincheta : MonoBehaviour
{
    public bool puedeTablon;
    public bool estaLibre = true;
    public bool puntoFijo;

    public Vector3 inicial;

    private void Awake()
    {
        inicial = transform.parent.position;
    }


    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -3);
        if (!puedeTablon)
        {
            transform.position -= Vector3.forward;
        }
        if (puntoFijo)
        {
            transform.parent.position = inicial;
        }
    }

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
