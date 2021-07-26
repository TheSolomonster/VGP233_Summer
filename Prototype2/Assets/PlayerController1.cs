using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject projectilePrefab;
    private float horizontalInput;
    private float xRange = 18.0f;
    private Vector3 heightOffset = new Vector3(0.0f, 1.0f,1.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        if (transform.position.x < -xRange) transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        if (transform.position.x > xRange) transform.position = new Vector3(xRange, transform.position.y, transform.position.z); 
        //fire projectiles
        if(Input.GetKeyDown(KeyCode.V))
        {
            //Launch Projectile
            Instantiate(projectilePrefab, transform.position + heightOffset, projectilePrefab.transform.rotation);
        }
    }
}
