using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 15.0f;
    public CharacterController controller;
    public float gravity = -9.82f;
    public float jumpHeight = 4f;
    public GameObject slider;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public int maxHealth = 10;
    public int health;
    Vector3 velocity;
    bool isGrounded = false;
    private int hitBuffer = 0;
    public bool gameWon = false;
    ReloadBar reloadBar;
    void Start()
    {
        reloadBar = slider.GetComponent<ReloadBar>();
        reloadBar.setMaxMin(0f, (float)maxHealth);
        health = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if(!gameWon)
        {
            reloadBar.setValue((float)health);
            hitBuffer--;
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0) velocity.y = -2f;
            if (health > 0)
            {
                float xInput = Input.GetAxis("Horizontal");
                float zInput = Input.GetAxis("Vertical");

                Vector3 move = transform.right * xInput + transform.forward * zInput;

                controller.Move(move * Time.deltaTime * speed);

                if (Input.GetButtonDown("Jump") && isGrounded) velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                velocity.y += gravity * Time.deltaTime;

                controller.Move(velocity * Time.deltaTime);
            }
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.gameObject.CompareTag("Charger") && hitBuffer <= 0 && !gameWon)
        {
            if (health > 0)
            {
                hitBuffer = 12;
                health--;
                if (health == 0) transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile") && hitBuffer <= 0 && !gameWon)
        {
            if (health > 0)
            {
                hitBuffer = 12;
                health-=2;
                if (health == 0) transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            }

        }
        else if(other.gameObject.CompareTag("Exit") && health > 0)
        {
            gameWon = true;
        }
        else if (other.gameObject.CompareTag("potion") && health > 0 && health < maxHealth)
        {
            health = maxHealth;
            Destroy(other.gameObject);
        }
    }


}
