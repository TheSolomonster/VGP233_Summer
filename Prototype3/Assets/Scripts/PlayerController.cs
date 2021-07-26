using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public float jumpForce = 10.0f;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem exposionPartical;
    public ParticleSystem dirtParticles;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        playerAnim.SetFloat("Speed_f", 16.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
        else if (isOnGround) dirtParticles.Play();
        if (Input.GetKeyDown(KeyCode.V) && isOnGround && !gameOver)
        {
            playerAnim.SetTrigger("Jump_trig");
            dirtParticles.Stop();
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground"))isOnGround = true;
        else if (collision.gameObject.CompareTag("obstacle"))
        {
            dirtParticles.Stop();
            exposionPartical.Play();
            gameOver = true;
            Debug.Log("GAME OVER!");
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
