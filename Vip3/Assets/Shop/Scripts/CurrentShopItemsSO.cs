using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrentShopItems", menuName = "CurrentShopItem")]
public class CurrentShopItemsSO : ScriptableObject
{
   public List<ShopItemSO> items;
}
