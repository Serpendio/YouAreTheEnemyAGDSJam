using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupRope : MonoBehaviour
{
    [SerializeField] Vector2 startPos, endPos;
    [SerializeField] GameObject ropeSegment;
    [SerializeField] float segmentLength;
    [SerializeField] HingeJoint2D endConnection;

    private void Awake()
    {
        float dist = (startPos - endPos).magnitude;

        int numSegments = Mathf.CeilToInt(segmentLength / dist);
        segmentLength = dist / numSegments;
        for (int i = 0; i < numSegments; i++)
        {

        }
    }
}
