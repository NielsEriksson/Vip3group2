using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIManager : MonoBehaviour
{
    public GameObject ShopUIObject;//The parent object containing the UI , currently called "BackGround"
    public GameObject CustomizationsTab;//Customizations upgrade tab background object , currently called "CTab"
    public GameObject MechanicsTab;//Mechanics upgrade tab background object , currently called "MTab"
    public GameObject ShopItemUIPrefab;//The prefab for SHop item UI objects
    public CurrentShopItemsSO currentShopItems;
    // Start is called before the first frame update
    private void Start()
    {
        //for testing purposes
        LoadAndOpenShopUI();
    }
    public void OpenShopUI()
    {
        ShopUIObject.SetActive(true);
    }
    public void LoadAndOpenShopUI()
    {
        ClearShopItemsObjects();
        CreateAllShopItemsObjects();
        ShopUIObject.SetActive(true);
    }

    private void ClearShopItemsObjects()
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
    private void CreateAllShopItemsObjects()
    {
        if(currentShopItems.items.Count == 0) return;
        foreach(ShopItemSO item in currentShopItems.items)
        {
            if(item.ItemType == ShopItemSO.ItemTypes.Mechanic)
            {
                LoadShopItemUIObject(MechanicsTab, item);
            }
            else
            {
                LoadShopItemUIObject(CustomizationsTab, item); 
            }
        }
    }
    public void LoadShopItemUIObject(GameObject tab, ShopItemSO shopItemSO)
    {
        GameObject gameObject = Instantiate(ShopItemUIPrefab, tab.transform);
        gameObject.GetComponent<ShopItemUI>().LoadItemUI(shopItemSO);
    }
}
