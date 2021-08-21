using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;

    private float maxTorque = 10.0f;
    private float xRange = 4.0f;
    private float startingY = -5.0f;
    private Rigidbody targetRb;
    public int pointValue;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), startingY, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Bad")&& !other.CompareTag("Good"))
        {
            if (CompareTag("Good")) gameManager.gameOver();
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if(!gameManager.gameover)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.updateScore(pointValue);
        }
    }
}
