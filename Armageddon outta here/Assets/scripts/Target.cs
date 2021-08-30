
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public void TakeDamage(float dmg)
    {
        Debug.Log(health);
        health -= dmg;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
