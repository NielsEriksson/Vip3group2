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
    [HideInInspector] ShopItemSO shopItem;
    
    public void LoadItemUIData(ShopItemSO shopItemSO)//Set all correct data in the UI Elements such as text and icons
    {
        shopItem = shopItemSO;
        itemNameTxt.text = shopItem.ItemName;
        if(shopItem.ItemIcon!=null)itemImage.sprite = shopItem.ItemIcon;
        itemCostTxt.text = shopItem.ItemCost.ToString();
        if (shopItem.ItemType == ShopItemSO.ItemTypes.Costumization) { coinIcon.SetActive(true); }
        else { starIcon.SetActive(true); }
    }

    public void PurchaseUpgrade()
    {
        string currencyType;
        if (shopItem.ItemType == ShopItemSO.ItemTypes.Mechanic) currencyType = "Star";
        else currencyType = "Coin";//Set currency type string depending on upgrade type


        if (CurrencyManager.Instance.CanAfford(shopItem.ItemCost, currencyType))//checks if player can afford it and invokes the shop item event if they can
        {
            
            shopItem.ItemEvent.Invoke();
            PlayerPrefs.SetInt(shopItem.ItemName, 1);
            if(currencyType == "Star") CurrencyManager.Instance.ChangeStarCount(-shopItem.ItemCost);
            else if(currencyType == "Coin") CurrencyManager.Instance.ChangeCoinCount(-shopItem.ItemCost);
            Destroy(gameObject);
        }
    }
}
