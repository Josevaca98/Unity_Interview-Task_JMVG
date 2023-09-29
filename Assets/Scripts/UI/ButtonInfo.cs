using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    // Identifier for the item associated with this UI element.
    public int itemID;
    // Reference to the TextMeshProUGUI components displaying price and quantity.
    public TextMeshProUGUI priceText, quantityText;
    // Reference to the ShopManager GameObject.
    public GameObject ShopManager;

    void Update()
    {
        // Update the displayed price text based on the itemID.
        priceText.text = "Price: $" + ShopManager.GetComponent<ShopManager>().shopItems[2,itemID].ToString();
        // Update the displayed quantity text based on the itemID.
        quantityText.text = ShopManager.GetComponent<ShopManager>().shopItems[3,itemID].ToString();    
    }
}
