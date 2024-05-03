using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour, IInteractable
{
    public string objectName;
    public Sprite img; 

    public void Interact()
    {
        Debug.Log("you picke me up: " + objectName);
        bool added = Inventory.Instance.AddToInventory(this);
        if (added)
        {
            Debug.Log("obg is added");
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("obj not added");
        }

        
    }

}
