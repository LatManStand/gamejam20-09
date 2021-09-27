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

    private AudioSource audioSource;


    private void Awake()
    {
        if (!esTablon)
        {
            PuzzleManager.instance.piezas++;
        }
        audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pieza"))
        {
            Tablon tablon = GetComponentInParent<Tablon>();
            if (cuerda != null)
            {
                if (tablon == null)
                {
                    if (audioSource != null)
                    {
                        audioSource.Play();
                    }
                    cuerda.StopTirar();

                    if (cuerda.cuerda.StartPoint == this)
                    {
                        transform.Translate((cuerda.cuerda.StartPoint.position - cuerda.cuerda.EndPoint.position).normalized * 0.1f);
                    }
                    else
                    {
                        transform.Translate((cuerda.cuerda.EndPoint.position - cuerda.cuerda.StartPoint.position).normalized * 0.1f);
                    }
                }
                else
                {
                    if (audioSource != null)
                    {
                        audioSource.Play();
                    }
                    cuerda.StopTirar();

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
            else
            {
                if (tablon != null)
                {
                    if (collision.collider.gameObject != tablon.startPoint && collision.collider.gameObject != tablon.endPoint)
                    {
                        if (audioSource != null)
                        {
                            audioSource.Play();
                        }

                        tablon.GetComponent<Pieza>().cuerda.StopTirar();
                    }
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
