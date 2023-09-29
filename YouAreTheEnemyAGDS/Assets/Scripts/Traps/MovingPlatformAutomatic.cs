using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingPlatformAutomatic : MonoBehaviour, ITrapBase
{
    Vector2 startPoint;
    bool isMoving, movingToEnd, isTouchingPlayer;
    float t;

    [SerializeField] Vector2 endPoint;
    [SerializeField] float moveSpeed;
    [SerializeField] bool movePlayer, ghostCanInteract;
    [SerializeField] Transform player; // can make this a reference in level controller later

    [SerializeField] private AudioSource movingPlatformSFX;

    private void Awake()
    {
        startPoint = transform.position;
    }

    public void Trigger(bool byGhost = true)
    {
        if (byGhost && !ghostCanInteract || isMoving) return;

        isMoving = true;
        movingToEnd = !movingToEnd;
        movingPlatformSFX.Play();
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            // yeah I know I could make this more efficient, but meh
            t += Time.deltaTime * moveSpeed / endPoint.magnitude * (movingToEnd ? 1 : -1);
            if (t <= 0 || t >= 1) isMoving = false;
            var oldPos = transform.position;
            transform.position = Vector3.Lerp(startPoint, startPoint + endPoint, t);
            if (movePlayer && isTouchingPlayer) player.position += transform.position - oldPos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) isTouchingPlayer = true;
    }
    

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) isTouchingPlayer = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + (Vector3)endPoint, 0.2f);
    }
}
