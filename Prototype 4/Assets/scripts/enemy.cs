using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent < Rigidbody>();
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        if(transform.position.y < -15.0f)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }
}
