using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour, IInteractable
{
    public string objectName;

    public void Interact()
    {
        Debug.Log("you picke me up: " + objectName);
    }

}
