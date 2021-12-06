using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // fields
    public PlayerController controller; //accessing PlayerController script methods

    float horizontalMove = 0f;
    float walkSet = 0f;
    public float runSpeed = 40f;

    bool jump = false;
    bool crouch = false;

    private Animator _animator;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        walkSet = horizontalMove;

        if (horizontalMove < 0)
        {
            walkSet = horizontalMove * -1;
        }
        _animator.SetFloat("walk", walkSet);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }


        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;

        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        _animator.SetBool("crouch", crouch);
        _animator.SetBool("crouchend", crouch);
        _animator.SetBool("jump", jump);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}