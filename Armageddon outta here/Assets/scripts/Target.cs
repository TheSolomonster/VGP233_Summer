
using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    private Animator anim;
    bool dead = false;
    public float health = 50f;
    public AudioSource source;
    public AudioClip clip;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (health <= 10 && (gameObject.CompareTag("Charger"))) anim.SetBool("Dying", true);
        else if (gameObject.CompareTag("Charger") && health > 10) anim.SetBool("Dying", false);
    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        Debug.Log(health);
        if (health <= 0f && !dead)
        {
            source.PlayOneShot(clip);
            dead = true;
            Invoke("Die", .86f);
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
