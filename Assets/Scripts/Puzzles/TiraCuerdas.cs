using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiraCuerdas : MonoBehaviour
{
    [HideInInspector]
    public CuerdaPuente cuerda;

    public bool clicked = false;
    public float speed = 0.3f;
    public float distanceMult = 0.2f;


    private void Awake()
    {
        cuerda = transform.GetComponentInParent<CuerdaPuente>();
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            clicked = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            clicked = false;
            cuerda.tirando = false;
        }
        */
        if (clicked && Vector3.Distance(cuerda.ropeSegments[cuerda.segmentLength / 2].posNow, cuerda.ropeSegments[cuerda.segmentLength / 2 - 2].posNow) >
            Vector3.Distance(cuerda.EndPoint.position, cuerda.StartPoint.position) * distanceMult
            && !cuerda.tirando
            && (Vector2.Dot(cuerda.StartPoint.GetComponentInParent<Pieza>().lastMovement, cuerda.EndPoint.position - cuerda.StartPoint.position) <= 0.0f || cuerda.StartPoint.GetComponentInParent<Pieza>().lastMovement == Vector2.zero)
            && (Vector2.Dot(cuerda.EndPoint.GetComponentInParent<Pieza>().lastMovement, cuerda.StartPoint.position - cuerda.EndPoint.position) <= 0.0f || cuerda.EndPoint.GetComponentInParent<Pieza>().lastMovement == Vector2.zero))
        {
            cuerda.tirando = true;
            cuerda.StartPoint.GetComponentInParent<Pieza>().lastMovement = cuerda.EndPoint.position - cuerda.StartPoint.position;
            cuerda.EndPoint.GetComponentInParent<Pieza>().lastMovement = cuerda.StartPoint.position - cuerda.EndPoint.position;
            //clicked = false;
            StartCoroutine(nameof(Tirar));

        }

        /*
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(nameof(Tirar));
        }
        else */
        if (Input.GetKeyUp(KeyCode.T))
        {
            StopCoroutine(nameof(Tirar));
        }
    }

    void FixedUpdate()
    {

        if (clicked)
        {
            CuerdaPuente.RopeSegment aux = cuerda.ropeSegments[cuerda.segmentLength / 2];
            Vector3 proj = (cuerda.EndPoint.position + cuerda.StartPoint.position) / 2f + Vector3.Project(MouseToWorld.instance.transform.position, Vector3.Cross(cuerda.EndPoint.position - cuerda.StartPoint.position, Vector3.forward));
            //+ ((cuerda.EndPoint.position - cuerda.StartPoint.position) / 2);
            aux.posNow = proj;
            aux.posOld = proj;
            aux.posNow.z = cuerda.ropeSegments[cuerda.segmentLength / 2 - 1].posNow.z;
            aux.posOld.z = cuerda.ropeSegments[cuerda.segmentLength / 2 - 1].posNow.z;
            cuerda.ropeSegments[cuerda.segmentLength / 2] = aux;

            aux = cuerda.ropeSegments[cuerda.segmentLength / 2 - 1];
            aux.posNow = proj;
            aux.posOld = proj;
            aux.posNow.z = cuerda.ropeSegments[cuerda.segmentLength / 2 - 2].posNow.z;
            aux.posOld.z = cuerda.ropeSegments[cuerda.segmentLength / 2 - 2].posNow.z;
            cuerda.ropeSegments[cuerda.segmentLength / 2 - 1] = aux;

            aux = cuerda.ropeSegments[cuerda.segmentLength / 2 + 1];
            aux.posNow = proj;
            aux.posOld = proj;
            aux.posNow.z = cuerda.ropeSegments[cuerda.segmentLength / 2].posNow.z;
            aux.posOld.z = cuerda.ropeSegments[cuerda.segmentLength / 2].posNow.z;
            cuerda.ropeSegments[cuerda.segmentLength / 2 + 1] = aux;
        }


        transform.position = cuerda.ropeSegments[cuerda.segmentLength / 2].posNow;
    }

    public IEnumerator Tirar()
    {
        while (true)
        {
            if (cuerda.EndPoint != MouseToWorld.instance.transform)
            {

                Vector3 direction = cuerda.EndPoint.position - cuerda.StartPoint.position;
                if (direction.magnitude > 1.0f)
                {
                    direction.Normalize();
                }
                cuerda.EndPoint.root.position -= direction * speed;
                cuerda.StartPoint.root.position += direction * speed;
            }
            yield return new WaitForFixedUpdate();
        }
    }
    private void OnMouseDown()
    {
        clicked = true;
    }

    private void OnMouseUp()
    {
        clicked = false;
        cuerda.tirando = false;
    }

}
