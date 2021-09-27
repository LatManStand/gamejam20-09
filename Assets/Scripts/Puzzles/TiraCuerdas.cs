using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiraCuerdas : MonoBehaviour
{
    [HideInInspector]
    public CuerdaPuente cuerda;

    public bool clicked = false;
    public float speed = 0.3f;
    public float distanceMult = 1.5f;


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
            && (Vector2.Dot(cuerda.StartPoint.GetComponentInParent<Pieza>().lastMovement.normalized, (cuerda.EndPoint.position - cuerda.StartPoint.position).normalized) <= 0.3f || cuerda.StartPoint.GetComponentInParent<Pieza>().lastMovement == Vector2.zero)
            && (Vector2.Dot(cuerda.EndPoint.GetComponentInParent<Pieza>().lastMovement.normalized, (cuerda.StartPoint.position - cuerda.EndPoint.position).normalized) <= 0.3f || cuerda.EndPoint.GetComponentInParent<Pieza>().lastMovement == Vector2.zero))
        {
            cuerda.tirando = true;

            if (cuerda.StartPoint.GetComponentInParent<Tablon>() != null)
            {
                cuerda.StartPoint.GetComponentInParent<Tablon>().startPoint.GetComponentInParent<Pieza>().lastMovement = Vector2.zero;
                cuerda.StartPoint.GetComponentInParent<Tablon>().endPoint.GetComponentInParent<Pieza>().lastMovement = Vector2.zero;
            }
            else
            {
                cuerda.StartPoint.GetComponentInParent<Pieza>().lastMovement = cuerda.EndPoint.position - cuerda.StartPoint.position;
            }
            if (cuerda.EndPoint.GetComponentInParent<Tablon>() != null)
            {
                cuerda.EndPoint.GetComponentInParent<Tablon>().startPoint.GetComponentInParent<Pieza>().lastMovement = Vector2.zero;
                cuerda.EndPoint.GetComponentInParent<Tablon>().endPoint.GetComponentInParent<Pieza>().lastMovement = Vector2.zero;
            }
            else
            {
                cuerda.EndPoint.GetComponentInParent<Pieza>().lastMovement = cuerda.StartPoint.position - cuerda.EndPoint.position;
            }
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
            Vector2 u = MouseToWorld.instance.transform.position - (cuerda.StartPoint.position + cuerda.EndPoint.position) / 2f;
            // Vector2 v = Vector3.Cross(cuerda.EndPoint.position - cuerda.StartPoint.position, Vector3.forward);
            Vector2 v = Vector2.Perpendicular(cuerda.EndPoint.position - cuerda.StartPoint.position);


            Vector3 proj = Mathf.Cos(Mathf.Deg2Rad * Vector2.Angle(u, v)) * u.magnitude * v.normalized;
            proj += (cuerda.StartPoint.position + cuerda.EndPoint.position) / 2f;
            proj.z = -3;


            //Vector3 proj = (cuerda.EndPoint.position + cuerda.StartPoint.position) / 2f + Vector3.Project(MouseToWorld.instance.transform.position, Vector3.Cross(cuerda.EndPoint.position - cuerda.StartPoint.position, Vector3.forward));
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
