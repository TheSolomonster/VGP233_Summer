using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    public float offsetXValue;
    private Vector3 offset = new Vector3( 0.0f,0.0f,0.0f);

    // Start is called before the first frame update
    void Start()
    {
        offset.x = offsetXValue;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}
