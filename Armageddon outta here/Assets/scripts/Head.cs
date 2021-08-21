using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public Transform playerBody;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float rotationY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        float rotationX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        xRotation -= rotationY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * rotationX);
    }
}
