using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SetupRope : MonoBehaviour
{
    [SerializeField] Vector2 endPos;
    [SerializeField] HingeJoint2D ropeSegment;
    [SerializeField] float segmentLength;
    [SerializeField] HingeJoint2D endConnection;

    private void Awake()
    {
        float dist = endPos.magnitude;

        // work out number of segments and readjust size
        int numSegments = Mathf.CeilToInt(dist / segmentLength);
        segmentLength = dist / numSegments;
        Vector3 offset = 0.45f * segmentLength * Vector3.right;

        // adjust visual size of rope
        var scale = ropeSegment.transform.localScale;
        scale.x = segmentLength / ropeSegment.GetComponent<SpriteRenderer>().size.x;
        ropeSegment.transform.localScale = scale;

        // place segments
        var lastSegment = Instantiate(ropeSegment, transform.position, Quaternion.identity, transform);
        lastSegment.connectedBody = GetComponent<Rigidbody2D>();
        lastSegment.connectedAnchor = Vector2.zero;
        for (int i = 1; i < numSegments; i++)
        {
            var newSegment = Instantiate(ropeSegment, transform.position + (i * offset), Quaternion.identity, transform); // yeah yeah, I'll adjust the i later
            newSegment.connectedBody = lastSegment.GetComponent<Rigidbody2D>();
            lastSegment = newSegment;
        }

        if (endConnection != null)
        {
            endConnection.connectedBody = lastSegment.GetComponent<Rigidbody2D>();
            endConnection.connectedAnchor = new(0.45f, 0);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + (Vector3)endPos, 0.1f);
    }
}
