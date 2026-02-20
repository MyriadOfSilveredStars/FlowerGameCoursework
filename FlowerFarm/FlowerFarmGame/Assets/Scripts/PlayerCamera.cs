using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCamera : MonoBehaviour
{   
    public float sensX; //these control the camera sensitivity
    public float sensY;

    public Transform orientation; //controls the orientation of the camera and player

    float xRotation;
    float yRotation; //controls the rotation of the camera

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //get the mouse input each update
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //stops the player looking up or down more than 90 degrees

        //now rotate the camera accordingly
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); 
        //and then the player
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);


    }
}
