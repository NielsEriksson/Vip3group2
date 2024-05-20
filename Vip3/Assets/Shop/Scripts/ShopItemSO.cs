using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ShopItem", menuName = "ShopItem")]
public class ShopItemSO : ScriptableObject
{

    public enum ItemTypes
    {
        Mechanic,
        Costumization
    }
    public ItemTypes ItemType;
    public string ItemName;
    public UnityEvent ItemEvent;
    public int ItemCost;
    public Sprite ItemIcon;
    public ShopItemSO preRequisite;
    public bool multiPurchase;
    
    public bool CheckPlayerPrefItem() //Checks if a playerpref with the item name exists, representing the upgrade being "bought" . The player pref only exists once the upgrade is bought
    {
        return PlayerPrefs.HasKey(ItemName);
    }
    public bool CheckPrerequisite()//returns false if there is a prerequisite not unlocked yet, true otherwise
    {
        if (preRequisite != null && !preRequisite.CheckPlayerPrefItem()) return false; 
        else return true;
    }
}
