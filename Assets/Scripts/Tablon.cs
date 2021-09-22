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
    }

    public void SetEnd(Transform end)
    {
        endPoint = end;
    }

    public void Update()
    {
        line.SetPosition(0, startPoint.position);
        line.SetPosition(1, endPoint.position);
        chincheta.position = Vector3.Lerp(startPoint.position, endPoint.position, 0.5f);

    }
}
