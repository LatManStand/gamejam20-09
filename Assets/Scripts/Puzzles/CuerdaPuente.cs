using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class CuerdaPuente : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;

    private LineRenderer lineRenderer;
    
    public float ropeSegLen = 0.25f;
    [HideInInspector]
    public int segmentLength = 35;
    [HideInInspector]
    public List<RopeSegment> ropeSegments = new List<RopeSegment>();
    public float lineWidth = 0.1f;

    public bool tirando;

    public TiraCuerdas tiraCuerdas;


    private AudioSource audioSource;
    public AudioClip chin;
    public AudioClip pon;

    // Use this for initialization
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Vector3 ropeStartPoint = StartPoint.position - Vector3.forward * 3.1f;
        tiraCuerdas = transform.GetChild(0).GetComponent<TiraCuerdas>();
        audioSource = transform.GetComponent<AudioSource>();

        for (int i = 0; i < segmentLength; i++)
        {
            ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y -= ropeSegLen;

        }
        StartCoroutine(nameof(Recalculate));
    }

    // Update is called once per frame
    void Update()
    {
        DrawRope();
    }

    private void FixedUpdate()
    {
        Simulate();
    }

    public IEnumerator Recalculate()
    {
        while (true)
        {
            int desiredSegmentLength = Mathf.CeilToInt(Vector2.Distance(StartPoint.position, EndPoint.position) / ropeSegLen + 5);

            if (desiredSegmentLength < segmentLength * 0.9f)
            {
                ropeSegments.RemoveAt(segmentLength - 1);
                segmentLength--;


            }
            else if (desiredSegmentLength > segmentLength * 1.1f)
            {
                ropeSegments.Add(new RopeSegment(ropeSegments[segmentLength - 1].posNow));
                segmentLength++;

            }

            yield return null;
        }
    }

    private void Simulate()
    {
        // SIMULATION
        Vector3 forceGravity = new Vector3(0f, -1f);

        for (int i = 1; i < segmentLength; i++)
        {
            if (!(i == segmentLength / 2 && tirando))
            {

                RopeSegment firstSegment = ropeSegments[i];
                Vector3 velocity = firstSegment.posNow - firstSegment.posOld;
                firstSegment.posOld = firstSegment.posNow;
                firstSegment.posNow += velocity;
                firstSegment.posNow += forceGravity * Time.fixedDeltaTime;
                ropeSegments[i] = firstSegment;
            }
        }

        //CONSTRAINTS
        for (int i = 0; i < 50; i++)
        {
            ApplyConstraint();
        }
    }

    private void ApplyConstraint()
    {
        //Constrant to First Point 
        RopeSegment firstSegment = ropeSegments[0];
        Vector3 aux = StartPoint.position;
        aux.z = -3.1f;
        firstSegment.posNow = aux;
        ropeSegments[0] = firstSegment;


        //Constrant to Second Point 
        RopeSegment endSegment = ropeSegments[ropeSegments.Count - 1];
        aux = EndPoint.position;
        aux.z = -3.1f;
        endSegment.posNow = aux;
        ropeSegments[ropeSegments.Count - 1] = endSegment;

        for (int i = 0; i < segmentLength - 1; i++)
        {
            if (!((i == segmentLength / 2 - 1 || i == segmentLength / 2) && tirando))
            {
                RopeSegment firstSeg = ropeSegments[i];
                RopeSegment secondSeg = ropeSegments[i + 1];

                float dist = (firstSeg.posNow - secondSeg.posNow).magnitude;
                float error = Mathf.Abs(dist - ropeSegLen);
                Vector2 changeDir = Vector2.zero;

                if (dist > ropeSegLen)
                {
                    changeDir = (firstSeg.posNow - secondSeg.posNow).normalized;
                }
                else if (dist < ropeSegLen)
                {
                    changeDir = (secondSeg.posNow - firstSeg.posNow).normalized;
                }

                Vector3 changeAmount = changeDir * error;
                if (i != 0)
                {
                    firstSeg.posNow -= changeAmount * 0.7f; // AQUI TOCO DESDE 0.5
                    ropeSegments[i] = firstSeg;
                    secondSeg.posNow += changeAmount * 0.7f;
                    ropeSegments[i + 1] = secondSeg;
                }
                else
                {
                    secondSeg.posNow += changeAmount;
                    ropeSegments[i + 1] = secondSeg;
                }
            }
        }
    }

    private void DrawRope()
    {
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePositions = new Vector3[segmentLength];
        for (int i = 0; i < segmentLength; i++)
        {
            ropePositions[i] = ropeSegments[i].posNow;
        }

        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
    }

    public struct RopeSegment
    {
        public Vector3 posNow;
        public Vector3 posOld;

        public RopeSegment(Vector3 pos)
        {
            posNow = pos;
            posOld = pos;
        }
    }

    public void Chin()
    {
        audioSource.PlayOneShot(chin);
    }

    public void Pon()
    {
        audioSource.PlayOneShot(pon);
    }
}
