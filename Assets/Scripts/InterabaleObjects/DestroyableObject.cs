using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour, IInteractable
{
    public string objectName;

    public void Interact()
    {
        Debug.Log("you distroyed me: " + objectName);
    }
}
