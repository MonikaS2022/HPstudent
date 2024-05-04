using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCanvas : MonoBehaviour
{

    public TextMeshProUGUI placeHolder1;
    public TextMeshProUGUI placeHolder2;
    public TextMeshProUGUI amount;
    public Image img1;
    public Image img2;

    private void OnEnable()
    {
        Inventory.OnInventoryChanged += UpdateInventoryUI;
    }
    private void OnDisable()
    {
        Inventory.OnInventoryChanged -= UpdateInventoryUI;
    }

    void Start()
    {
        placeHolder1.text = "nothing yet";
        placeHolder2.text = "nothing yet";
        amount.text = Inventory.Instance.maxInventories.ToString();
        Debug.Log(Inventory.Instance.maxInventories.ToString());
    }



    void UpdateInventoryUI()
    {
        if (Inventory.Instance.GetName(0) != string.Empty)
        {
            placeHolder1.text = Inventory.Instance.GetName(0);
            
            img1.sprite = Inventory.Instance.inventory[0].img;
            img1.enabled = true;
        }
        if(Inventory.Instance.GetName(1) != string.Empty)
        {
            placeHolder2.text = Inventory.Instance.GetName(1);
            
            img2.sprite = Inventory.Instance.inventory[1].img;
            img2.enabled = true;
        }
        
        
    }
}
