using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float timer = 0.0f;
    public float timerAmount = 2.0f;
    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("Timer", 0, 1);
    }
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && timer<=0)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            timer = timerAmount;
        }
    }
    private void Timer()
    {
        timer--;
    }
}
