using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{

    public int itemID;
    public TextMeshProUGUI priceText, quantityText;
    public GameObject ShopManager;

    void Update()
    {
        priceText.text = "Price: $" + ShopManager.GetComponent<ShopManager>().shopItems[2,itemID].ToString();    
        quantityText.text = ShopManager.GetComponent<ShopManager>().shopItems[3,itemID].ToString();    
    }
}
