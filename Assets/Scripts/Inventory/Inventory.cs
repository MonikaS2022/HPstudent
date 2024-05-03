using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;


//SINGELTON
public class Inventory : MonoBehaviour
{
  public static Inventory Instance { get; private set; }

    public int maxInventories = 2;
    public PickableObject[] inventory;
    public static Action OnInventoryChanged;
    public static void RaiseOnInventoryChanged() => OnInventoryChanged?.Invoke();


    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        inventory = new PickableObject[maxInventories];
    }

    public bool AddToInventory(PickableObject pickable)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = pickable;
                Debug.Log("Array Added " + pickable.name);
                RaiseOnInventoryChanged();
                return true;
                              
            }
          
        }
        Debug.Log("list is full");
        return false;
    }

    public string GetName(int nr)
    {
        if (inventory[nr] == null)
        {
            return string .Empty;
        }
        return inventory[nr].objectName;
    }
   
}
