using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIManager : MonoBehaviour
{
    public static ShopUIManager Instance { get; private set; } //makes this ShopUIManager a singleton for easy access
    public GameObject ShopUIObject;//The parent object containing the UI , currently called "BackGround"
    public GameObject CustomizationsTab;//Customizations upgrade tab background object , currently called "CTab"
    public GameObject MechanicsTab;//Mechanics upgrade tab background object , currently called "MTab"
    public GameObject ShopItemUIPrefab;//The prefab for SHop item UI objects
    public CurrentlyAvailableShopItemsSO currentShopItems;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    public void OpenShopUI()//Simply activate the UI if the current shop npc has been visited before
    {
        ShopUIObject.SetActive(true);
    }
    public void LoadAndOpenShopUI()//Load New Shop Items if it is the first time the current shop npc is visited
    {
        ClearShopItemsObjects();
        CreateAllShopItemsObjects();
        ShopUIObject.SetActive(true);
    }
    public void ReloadShop()
    {
        ClearShopItemsObjects();
        CreateAllShopItemsObjects();
    }

    private void ClearShopItemsObjects()//Deletes all existing Shop Item UI objects
    {
        foreach (Transform child in MechanicsTab.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in CustomizationsTab.transform)
        {
            Destroy(child.gameObject);
        }
    }
    private void CreateAllShopItemsObjects()//Creates new shop item UI objects
    {
        if(currentShopItems.items.Count == 0) return;
        foreach(ShopItemSO item in currentShopItems.items)
        {
            //Checks if the players has previously purchased the upgrade through playerprefs,
            //as the currentlyUnlockedShopItems SO List would reset when the game is closed and reopened but not the player prefs
            if (item.CheckPlayerPrefItem()&&!item.multiPurchase) { continue; }
            if(item.CheckPrerequisite()==false) { continue; }
            if (item.ItemType == ShopItemSO.ItemTypes.Mechanic)//checks which type of upgrade it is and sets it to the according tab
            {
                LoadShopItemUIObject(MechanicsTab, item);
            }
            else
            {
                LoadShopItemUIObject(CustomizationsTab, item); 
            }
        }
    }
    public void LoadShopItemUIObject(GameObject tab, ShopItemSO shopItemSO) //Instantiates a new instance of the ShopItemUIPrefab and calls for the LoadItemUIData method 
    {
        GameObject gameObject = Instantiate(ShopItemUIPrefab, tab.transform);
        gameObject.GetComponent<ShopItemUI>().LoadItemUIData(shopItemSO);
    }
}
