using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteractable
{
    void Interact();
}
public class ShopNPC : MonoBehaviour, IInteractable
{
    [Tooltip("The new shop items available at this specific shop")][SerializeField] List<ShopItemSO> ItemsAvailable; //The new shop items available at this specific shop
    private bool isFirstTimeVisiting;
    private CurrentShopItemsSO currentShopItems; //All unpurchased shop items the player currently has unlocked Scriptable Object
    private ShopUIManager shopUIManager;

    void Start()
    {
        shopUIManager = GameObject.FindWithTag("ShopUI").GetComponent<ShopUIManager>();
    }

    public void Interact()
    {
        if(isFirstTimeVisiting)
        {
            foreach (ShopItemSO item in ItemsAvailable)
            {
                if(currentShopItems.items.Count!=0 && currentShopItems.items.Contains(item)) {continue;}
                if (item.CheckPlayerPrefItem()) { continue; }
                currentShopItems.items.Add(item);
            }
            shopUIManager.LoadAndOpenShopUI();
        }
        else shopUIManager.OpenShopUI();
    }
}
