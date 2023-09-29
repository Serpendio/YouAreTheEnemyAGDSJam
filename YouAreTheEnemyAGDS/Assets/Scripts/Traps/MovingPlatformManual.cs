using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MovingPlatformManual : MonoBehaviour,  IPointerDownHandler
{
    [SerializeField] float moveAngle, endPos, startPos;
    Vector2 startPoint, endPoint;
    bool isClicked;

    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
    }

    public void CursorRelease(InputAction.CallbackContext context)
    {
        if (context.canceled) isClicked = false;
    }

    //shamelessly stolen from lordofduct @ https://forum.unity.com/threads/how-do-i-find-the-closest-point-on-a-line.340058/
    //linePnt - point the line passes through
    //lineDir - unit vector in direction of line, either direction works
    //pnt - the point to find nearest on line for
    public static Vector2 NearestPointOnLine(Vector2 linePnt, Vector2 lineDir, Vector2 pnt)
    {
        lineDir.Normalize();//this needs to be a unit vector
        var v = pnt - linePnt;
        var d = Vector2.Dot(v, lineDir);
        return linePnt + lineDir * d;
    }
    private void Awake()
    {
        startPoint = transform.position + Quaternion.Euler(0, 0, moveAngle) * Vector3.right * startPos;
        endPoint = transform.position + Quaternion.Euler(0, 0, moveAngle) * Vector3.left * endPos;
    }

    private void Update()
    {
        if (isClicked)
        {
            // get mouse pos in world
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value); // yep, shouldn't do cam.main either..
            var nearest = NearestPointOnLine(startPoint, endPoint - startPoint, mousePos);
            float distBetween = (endPoint - startPoint).magnitude;
            float distToStart = (nearest - startPoint).magnitude;
            float distToEnd = (endPoint - nearest).magnitude;
            if (distToStart > distBetween)
            {
                if (distToStart > distToEnd)
                    nearest = endPoint;
                else 
                    nearest = startPoint;
            }
            else if (distToEnd > distBetween)
            {
                if (distToStart > distToEnd)
                    nearest = endPoint;
                else
                    nearest = startPoint;
            }

            transform.position = nearest;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + Quaternion.Euler(0, 0, moveAngle) * Vector3.right * startPos, 0.2f);
        Gizmos.DrawWireSphere(transform.position + Quaternion.Euler(0, 0, moveAngle) * Vector3.left * endPos, 0.2f);
    }
}
