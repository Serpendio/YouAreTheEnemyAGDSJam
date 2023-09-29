using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GhostControls : MonoBehaviour
{
    [SerializeField] float interactRadius = 1f,
                        moveSpeed = 3f;
    [SerializeField] LayerMask trapMask;

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var hit = Physics2D.OverlapCircle(transform.position, interactRadius, trapMask);
            if (hit != null)
            {
                hit.GetComponent<ITrapBase>().Trigger();
            }
        }
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Mouse.current.position.value), moveSpeed * Time.fixedDeltaTime);
    }
}
