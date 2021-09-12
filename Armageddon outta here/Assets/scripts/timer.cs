using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class timer : MonoBehaviour
{
    public GameObject manager;
    private int time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = manager.GetComponent<gameManager>().timer;
        if(time%60<10) GetComponent<TextMeshProUGUI>().text = "Time left: " + (time - (time % 60)) / 60 + ":0" + time % 60;
        else GetComponent<TextMeshProUGUI>().text = "Time left: " + (time-(time%60))/60 + ":"+ time % 60;
    }
}
