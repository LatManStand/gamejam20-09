using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiraCuerdas : MonoBehaviour
{
    [HideInInspector]
    public CuerdaPuente cuerda;

    public bool clicked = false;
    public float speed = 0.3f;


    private void Awake()
    {
        cuerda = transform.parent.GetComponent<CuerdaPuente>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            clicked = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            clicked = false;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(nameof(Tirar));
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            StopCoroutine(nameof(Tirar));
        }

        if (clicked)
        {
            CuerdaPuente.RopeSegment aux = cuerda.ropeSegments[cuerda.segmentLength / 2];
            aux.posNow = MouseToWorld.instance.transform.position;
            aux.posOld = MouseToWorld.instance.transform.position;
            cuerda.ropeSegments[cuerda.segmentLength / 2] = aux;
        }


        transform.position = cuerda.ropeSegments[cuerda.segmentLength / 2].posNow;
    }

    public IEnumerator Tirar()
    {
        while (true)
        {
            Vector3 direction = cuerda.EndPoint.position - cuerda.StartPoint.position;
            if(direction.magnitude > 1.0f)
            {
                direction.Normalize();
            }
            cuerda.EndPoint.root.position -= direction * speed;
            cuerda.StartPoint.root.position += direction * speed;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }


}
