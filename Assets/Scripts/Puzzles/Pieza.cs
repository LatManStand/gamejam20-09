using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieza : MonoBehaviour
{
    public TiraCuerdas cuerda;

    public bool isColliding;
    public GameObject lastCollider;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pieza"))
        {
            isColliding = true;
            lastCollider = collision.collider.gameObject;
            if (cuerda != null)
            {
                cuerda.StopCoroutine(nameof(cuerda.Tirar));

                if (cuerda.cuerda.StartPoint == this)
                {
                    transform.Translate((cuerda.cuerda.StartPoint.position - cuerda.cuerda.EndPoint.position).normalized * 0.1f);
                }
                else
                {
                    transform.Translate((cuerda.cuerda.EndPoint.position - cuerda.cuerda.StartPoint.position).normalized * 0.1f);
                }
            }

        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (lastCollider == collision.collider)
        {
            isColliding = false;
        }
    }


}
