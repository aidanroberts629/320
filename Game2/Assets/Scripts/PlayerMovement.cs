using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    // fields
    public CharacterController controller;
    public float moveSpeed = 12f;
    public float jumpHeight = 3f;

    Vector3 velocity;
    public float gravity = -9.81f;

    public Transform floorChecker;
    public float floorDistance = 0.4f;
    public LayerMask floorMask;
    bool isOnFloor;

    public AudioSource source;
    public AudioClip footstep1;
    public AudioClip footstep2;
    public AudioClip footstep3;
    public AudioClip footstep4;
    public AudioClip footstep5;
    public AudioClip footstep6;

    double footstepTimer;
    double footstepTimerMax;

    // methods
    private void Awake()
    {
        source = gameObject.AddComponent<AudioSource>();
        footstepTimerMax = 0.33; //0.33s.. the length of each of the footstep mp3s
        footstepTimer = footstepTimerMax;
    }

    void Update()
    {
        isOnFloor = Physics.CheckSphere(floorChecker.position, floorDistance, floorMask);

        if (isOnFloor && velocity.y < 0)
            velocity.y = -2f; //forces player to the ground

        // setting up movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moving = transform.right * x + transform.forward * z;

        // actually moving
        controller.Move(moving * moveSpeed * Time.deltaTime);
        //Debug.Log("horz: " + x + "       , vert: " + z);

        // jumping
        if (Input.GetButtonDown("Jump") && isOnFloor)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        // dealing with gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // footstep audio
        footstepTimer -= Time.deltaTime; //updating footstep timer
        int footstepNum = 0;
        if (isOnFloor && PlayFootsteps() == true) //footsteps
        {
            // ensure NEW random footstep sound (one that wasn't *just* played)
            bool randCheck = true;
            int newNum = Random.Range(1, 6);
            while (randCheck)
            {
                if(newNum != footstepNum) //if new random sound isn't equal to the previous sound
                {
                    footstepNum = newNum; //setting the random num
                    randCheck = false; //breaking the loop
                }
                else
                    newNum = Random.Range(1, 6);
            }
            
            switch (footstepNum)
            {
                case 1:
                    source.PlayOneShot(footstep1);
                    break;
                case 2:
                    source.PlayOneShot(footstep2);
                    break;
                case 3:
                    source.PlayOneShot(footstep3);
                    break;
                case 4:
                    source.PlayOneShot(footstep4);
                    break;
                case 5:
                    source.PlayOneShot(footstep5);
                    break;
                case 6:
                    source.PlayOneShot(footstep6);
                    break;
            }

        }
    }
    public bool PlayFootsteps()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            /*isMoving*/ && footstepTimer <= 0)
        {
            footstepTimer = footstepTimerMax; //resets timer
            return true;
        }
        else
            return false;
    }
}
