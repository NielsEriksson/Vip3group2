using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrentShopItems", menuName = "CurrentShopItem")]
public class CurrentlyAvailableShopItemsSO : ScriptableObject
{
   public List<ShopItemSO> items; //A list of all currently unlocked Upgrade
}
