using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float moveSpeed, jumpVelocity;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float checkDist = 0.6f;

    Rigidbody2D rig;
    float movement;
    bool isGrounded, tryJump;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<float>();
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
            tryJump = true;
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, checkDist, groundLayer).collider != null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckGround();

        var vel = rig.velocity;
        vel.x = movement * moveSpeed;
        if (tryJump && isGrounded) vel.y = jumpVelocity;
        rig.velocity = vel;

        tryJump = false;
    }
}
