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
    private bool isFirstTimeVisiting;//checks whether it is the first time the player interact with this specific shop npc
    private CurrentlyUnlockedShopItemsSO currentlyUnlockedShopItems; //All unpurchased shop items the player currently has unlocked Scriptable Object
    public void Interact()
    {
        if(isFirstTimeVisiting)//If it is the first time visiting this npc the list of new upgrades is comapred to the list of already unlocked 
        {
            foreach (ShopItemSO item in ItemsAvailable)
            {
                //If it is the first time visiting this npc the list of new upgrades is comapred to the list of already unlocked 
                //This check is done incase we reload a new scene each time the player gets to a new room as the bool isFirstTimeVisiting would reset but not the currentlyUnlockedShopItems SO list
                if(currentlyUnlockedShopItems.items.Count!=0 && currentlyUnlockedShopItems.items.Contains(item)) {continue; }
                //Then checks if the players has previously purchased the upgrade through playerprefs,
                //as the currentlyUnlockedShopItems SO List would reset when the game is closed and reopened but not the player prefs
                if (item.CheckPlayerPrefItem()) { continue; }
                //If it gets to this point it means the Upgrade from this npc is completely new and should be added to the currentlyUnlockedShopItems
                currentlyUnlockedShopItems.items.Add(item);
            }
            ShopUIManager.Instance.LoadAndOpenShopUI();
        }
        else ShopUIManager.Instance.OpenShopUI();
    }
}
