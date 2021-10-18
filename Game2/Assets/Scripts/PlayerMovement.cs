using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        // jumping
        if (Input.GetButtonDown("Jump") && isOnFloor)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        // dealing with gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
