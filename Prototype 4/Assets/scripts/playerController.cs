using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed = 5.0f;
    public bool hasPowerUp = false;
    private float strength = 15.0f;
    public GameObject powerUpIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        powerUpIndicator.transform.position = transform.position + new Vector3(0.0f, -0.5f, 0.0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            powerUpIndicator.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 pushDirection =  collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(pushDirection * strength, ForceMode.Impulse);
        }
    }
    private void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }
}
