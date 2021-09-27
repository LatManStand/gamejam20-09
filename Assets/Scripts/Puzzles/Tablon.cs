using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablon : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    private LineRenderer line;

    public Transform chincheta;

    public Color chinchetaStart;
    public Color chinchetaEnd;
    public float alpha;

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
        chinchetaStart = startPoint.GetComponent<SpriteRenderer>().color;
        chinchetaStart.a = alpha;
        startPoint.GetComponent<SpriteRenderer>().color = chinchetaStart;
        startPoint.GetComponentInParent<Pieza>().lastMovement = Vector2.zero;
        if (end != MouseToWorld.instance.transform && end != null)
        {
            endPoint.root.SetParent(transform);
            chinchetaEnd = startPoint.GetComponent<SpriteRenderer>().color;
            chinchetaEnd.a = alpha;
            endPoint.GetComponent<SpriteRenderer>().color = chinchetaEnd;
            endPoint.GetComponentInParent<Pieza>().lastMovement = Vector2.zero;
        }
    }

    public void SetEnd(Transform end)
    {
        endPoint = end;
        if (end != MouseToWorld.instance.transform && end != null)
        {
            endPoint.root.SetParent(transform);
            chinchetaEnd = endPoint.GetComponent<SpriteRenderer>().color;
            chinchetaEnd.a = alpha;
            endPoint.GetComponent<SpriteRenderer>().color = chinchetaEnd;
            endPoint.GetComponentInParent<Pieza>().lastMovement = Vector2.zero;

        }
    }

    public void Update()
    {
        Vector3 aux1 = startPoint.position;
        aux1.z = -3;
        Vector3 aux2 = endPoint.position;
        aux2.z = -3;
        line.SetPosition(0, aux1);
        line.SetPosition(1, aux2);
        Vector3 pos = Vector3.Lerp(aux1, aux2, 0.5f);
        Vector3 distance = pos - transform.position;
        transform.position += distance;
        foreach (Transform child in transform)
        {
            child.position -= distance;
        }

        chincheta.position = pos;
    }

    public void Unlink()
    {
        chinchetaStart.a = 1.0f;
        startPoint.GetComponent<SpriteRenderer>().color = chinchetaStart;
        startPoint.parent.SetParent(null);
        if (endPoint != null && endPoint != MouseToWorld.instance)
        {
            chinchetaEnd.a = 1.0f;
            if (endPoint.GetComponent<SpriteRenderer>() != null)
            {
                endPoint.GetComponent<SpriteRenderer>().color = chinchetaEnd;
            }
            if (endPoint.parent != null)
            {
                endPoint.parent.SetParent(null);
            }
            else
            {
                endPoint.SetParent(null);
            }
        }
    }
}
