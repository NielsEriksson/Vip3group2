using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "UpgradeManagerSO", menuName = "UpgradeManagerSO")]
public class UpgradeManagerSO : ScriptableObject
{
   
    [SerializeField] private List<ShopItemSO> shopItems;

    public void Initiate()
    {
        foreach (ShopItemSO item in shopItems)
        {
            if (item.CheckPlayerPrefItem())
                item.ItemEvent?.Invoke();
        }
    }
    #region Mechanic Upgrade Methods
    public void UnlockLeft()
    {
        UpgradeManager.Instance.left = true;
    }
    public void UnlockJump()
    {
        Debug.Log("unlocked");
        UpgradeManager.Instance.jump = true;
    }
    public void UnlockDoubleJump()
    {
        UpgradeManager.Instance.doubleJump = true;
    }
    public void UnlockCrouch()
    {
        UpgradeManager.Instance.crouch = true;
    }
    public void UnlockCoins()
    {
        UpgradeManager.Instance.coins = true;
        CurrencyManager.Instance.ActivateCoinDisplay();
        foreach(Collectible collectible in CurrencyManager.Instance.allCollectibles)
        {
            if(collectible.type == Collectible.CollectibleType.Coin)
            {
                collectible.gameObject.SetActive(true);
            }
        }
    }
    public void UnlockCombat()
    {
        UpgradeManager.Instance.combat = true;
    }
    public void UnlockEnemies()
    {
       
        foreach(UnityEngine.Transform child in GameObject.FindWithTag("EnemyList").transform)
        {
            child.gameObject.SetActive(true);
        }
        UpgradeManager.Instance.enemies = true;
    }
    public void UnlockObstacles()
    {
        UpgradeManager.Instance.obstacles = true;
    }
    #endregion

    #region Customization Upgrade Methods
    public void UnlockBackgroundTexture()
    {
        UpgradeManager.Instance.backgroundTexture = true;
    }
    public void UnlockSideScroll()
    {
        UpgradeManager.Instance.sidescroll = true;
    }
    public void UnlockPlatformTexture()
    {
        UpgradeManager.Instance.platformTexture = true;
    }
    public void UnlockMusic()
    {
        UpgradeManager.Instance.music = true;
    }
    public void UnlockSFX()
    {
        UpgradeManager.Instance.sfx = true;
    }
    public void UnlockPlayerCustomization()
    {
        PlayerSkins.instance.ChangeToRandomColor();
        UpgradeManager.Instance.playerCustomization = true;
    }
    #endregion
}
