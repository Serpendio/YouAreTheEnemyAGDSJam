using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float moveSpeed, jumpVelocity;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float checkDist = 0.6f;
    [SerializeField] Canvas pauseMenu;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private Animator animator;

    Rigidbody2D rig;
    float movement;
    bool isGrounded, tryJump, climbingLadder, jumpHeld;

    private void OnEnable()
    {
        
    }

    void Awake()
    {
   
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<float>();
        animator.SetBool("IsMoving", movement != 0);
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
            tryJump = true;
    }

    public void HoldJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            jumpHeld = true;
        else if (context.canceled)
            jumpHeld = false;
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, checkDist, groundLayer).collider != null;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();

        var vel = rig.velocity;
        vel.x = movement * moveSpeed;
        if (tryJump && isGrounded)
        { 
            vel.y = jumpVelocity;
            jumpSoundEffect.Play();
            tryJump = false;
        }
        else if (jumpHeld)
        {
            if (climbingLadder)
            {
                vel.y = moveSpeed;
            }
            else if (isGrounded)
            {
                vel.y = jumpVelocity;
                jumpSoundEffect.Play();
            }
        }
        if (climbingLadder)
        {
            vel.y = Mathf.Max(vel.y, 0);
        }
        rig.velocity = vel;
    }

    public void ClimbLadder(bool climbing)
    {
        climbingLadder = climbing;
        //GetComponent<Rigidbody2D>().gravityScale = climbing ? 0 : 1;
    }

    public void Pause(InputAction.CallbackContext context)
    {
        pauseMenu.gameObject.SetActive(true);
    }

}
