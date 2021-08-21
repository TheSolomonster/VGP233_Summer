using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 15.0f;
    public CharacterController controller;
    public float gravity = -9.82f;
    public float jumpHeight = 4f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded = false;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) velocity.y = -2f;

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xInput + transform.forward * zInput;

        controller.Move(move * Time.deltaTime * speed);

        if (Input.GetButtonDown("Jump") && isGrounded) velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
    
}
