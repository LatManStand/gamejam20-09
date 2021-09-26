using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieza : MonoBehaviour
{
    public TiraCuerdas cuerda;

    public Vector2 lastMovement;

    public Transform objetivo;
    public bool puntuo;

    public bool esTablon;


    private void Awake()
    {
        PuzzleManager.instance.piezas++;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pieza"))
        {
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

    private void Update()
    {
        if (!esTablon)
        {

            if (Mathf.Abs(transform.position.x - objetivo.position.x) < 1f && Mathf.Abs(transform.position.y - objetivo.position.y) < 1f)
            {
                if (!puntuo)
                {
                    puntuo = true;
                    PuzzleManager.instance.piezasColocadas++;
                }
            }
            else
            {
                if (puntuo)
                {
                    puntuo = false;
                    PuzzleManager.instance.piezasColocadas--;
                }
            }
        }
    }

}
