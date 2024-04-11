using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SwitchCamera : MonoBehaviour
{

    public Camera camMain;
    public Camera camSecond;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            camSecond.enabled = true;
            camMain.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            camSecond.enabled = false;
            camMain.enabled = true; ;
        }
    }
}
