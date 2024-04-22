using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeManager", menuName = "UpgradeManager")]
public class UpgradeManager : ScriptableObject
{
    [SerializeField] private bool left;
    [SerializeField] private bool jump;
    [SerializeField] private bool doubleJump;
    [SerializeField] private bool crouch;

    [SerializeField] private List<ShopItemSO> shopItems;

    public bool Left { get { return left; } }
    public bool Jump { get { return jump; } }
    public bool DoubleJump { get { return doubleJump; } }
    public bool Crouch { get { return crouch; } }

    //private void Start()
    //{
    //    foreach(ShopItemSO item in shopItems)
    //    {
    //        if(item.CheckPlayerPrefItem())
    //            item.ItemEvent?.Invoke();
    //    }
    //}

    public void Initiate()
    {
        foreach (ShopItemSO item in shopItems)
        {
            if (item.CheckPlayerPrefItem())
                item.ItemEvent?.Invoke();
        }
    }

    public void UnlockLeft()
    {
        left = true;
    }

    public void UnlockJump()
    {
        Debug.Log("unlocked");
        jump = true;
    }

    public void UnlockDoubleJump()
    {
        doubleJump = true;
    }

    public void UnlockCrouch()
    {
        crouch = true;
    }
}
