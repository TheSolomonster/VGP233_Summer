
using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    bool dead = false;
    public float health = 50f;
    public AudioSource source;
    public AudioClip clip;
    public void TakeDamage(float dmg)
    {
        Debug.Log(health);
        health -= dmg;
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
