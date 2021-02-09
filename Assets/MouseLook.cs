using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour  
{
    //obviously how fast you look around, change to preference :)
    public float mouseSensitivity = 10000f;
    //this is so you can link the camera to the body
    public Transform playerBody;
    //start of moving y axis
    float xRotation = 0f;

    
    void Start()
    {
        //This code will hide and lock cursor so if you go past the screen with your mouse, it wouldn't end up on another monitor
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        //"Mouse X" and "Mouse Y" are Unity's base mouse input system
        //this is basically so you can access moving the camera with the mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        //to get the y axis to work properly, the minus is so your controls are not inverted
        xRotation -= mouseY;
        //so your pov doesnt go upside down when looking all the way up, or down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //this helps with the rotation of the x axis
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //To get the x axis to work properly
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
