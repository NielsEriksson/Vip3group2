using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    [SerializeField] TMP_Text itemNameTxt;
    [SerializeField] Image itemImage;
    [SerializeField] TMP_Text itemCostTxt;
    [SerializeField] GameObject starIcon,coinIcon;
    
    public void LoadItemUIData(ShopItemSO shopItem)//Set all correct data in the UI Elements such as text and icons
    {
        itemNameTxt.text = shopItem.ItemName;
        if(shopItem.ItemIcon!=null)itemImage.sprite = shopItem.ItemIcon;
        itemCostTxt.text = shopItem.ItemCost.ToString();
        if (shopItem.ItemType == ShopItemSO.ItemTypes.Costumization) { coinIcon.SetActive(true); }
        else { starIcon.SetActive(true); }
    }
}
