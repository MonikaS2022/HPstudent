using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    //public Transform player;
    //public float mouseSensitivity = 2f;
    //float cameraVerticalRotation = 0f;

    [SerializeField] Camera zoom;
    
    float zoomSpeed = 0.5f;
    float maxZoom = 1f;
    float minZoom = 4f;
    public float zoomStatus;

    private void Update()
    {
        //prev code, was not used?

        //float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        //float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        //cameraVerticalRotation -= inputY;
        //cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -45f, 45f);
        //transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        //player.Rotate(Vector3.up * inputX);

        //testing 13-05-24, annoying jumps when at limit

        if (zoom.orthographicSize > maxZoom && zoom.orthographicSize < minZoom) { zoom.orthographicSize -= (Input.mouseScrollDelta.y * zoomSpeed); }
        else if(zoom.orthographicSize >= minZoom) { zoom.orthographicSize -= Mathf.Abs(Input.mouseScrollDelta.y * zoomSpeed); }
        else { zoom.orthographicSize += Mathf.Abs(Input.mouseScrollDelta.y * zoomSpeed); }

        zoomStatus = zoom.orthographicSize;

    }
}

