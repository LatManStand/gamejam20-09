using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablon : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public LineRenderer line;

    public Transform chincheta;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        chincheta = transform.GetChild(0);
    }


    public void SetPoints(Transform start, Transform end)
    {
        startPoint = start;
        endPoint = end;
        startPoint.root.SetParent(transform);
        if (end != MouseToWorld.instance.transform)
        {
            endPoint.root.SetParent(transform);
        }
    }

    public void SetEnd(Transform end)
    {
        endPoint = end;
        if (end != MouseToWorld.instance.transform)
        {
            endPoint.root.SetParent(transform);
        }
    }

    public void Update()
    {
        Vector3 aux1 = startPoint.position - Vector3.forward;
        Vector3 aux2 = endPoint.position - Vector3.forward;
        line.SetPosition(0, aux1);
        line.SetPosition(1, aux2);
        chincheta.position = Vector3.Lerp(startPoint.position, endPoint.position, 0.5f);
        chincheta.position -= Vector3.forward * 1.01f;

    }

    private void OnDestroy()
    {
        startPoint.parent.SetParent(null);
        startPoint.parent.GetComponent<Collider2D>().enabled = true;
        if (endPoint != null)
        {
            if (endPoint.parent != null)
            {
                endPoint.parent.SetParent(null);
                endPoint.parent.GetComponent<Collider2D>().enabled = true;

            }
            else
            {
                endPoint.SetParent(null);
            }
        }
    }
}
