using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOutOfBounds : MonoBehaviour
{
    private float verticalBound = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > verticalBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -verticalBound) Debug.Log("GAME OVER");
    }
}
