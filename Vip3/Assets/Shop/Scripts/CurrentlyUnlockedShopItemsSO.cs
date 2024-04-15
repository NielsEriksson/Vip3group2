using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrentShopItems", menuName = "CurrentShopItem")]
public class CurrentlyUnlockedShopItemsSO : ScriptableObject
{
   public List<ShopItemSO> items; //A list of all currently unlocked Upgrade
}
