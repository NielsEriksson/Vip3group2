using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;
    [HideInInspector] public int diamondCount { get; private set; }
    [HideInInspector] public int coinCount { get; private set; }

    public TMP_Text diamondCountTxt;
    public TMP_Text coinCountTxt;

    public GameObject coinDisplay;

    [HideInInspector] public List<Collectible> allCollectibles;
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
    public void Start()
    {
        diamondCount = PlayerPrefs.GetInt("DiamonCount", 1);
        coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        diamondCountTxt.text = ": " + diamondCount.ToString();
        coinCountTxt.text = ": " + coinCount.ToString();
        if(!UpgradeManager.Instance.coins){coinDisplay.SetActive(false);}
    }

    public bool CanAfford(int price, string currencyType) //send in either "Star" or "Coin" as string when using this method
    {
        if (currencyType == "Diamond" && diamondCount - price >= 0) return true;
        else if (currencyType == "Coin" && coinCount - price >= 0) return true;
        else return false;
    }

    public void ChangeStarCount(int amount)
    {
        diamondCount+= amount;
        PlayerPrefs.SetInt("DiamonCount", diamondCount);
        Debug.Log(diamondCount);
        diamondCountTxt.text = ": " + diamondCount.ToString();
    }

    public void ChangeCoinCount(int amount)
    {
        coinCount+=amount;
        PlayerPrefs.SetInt("CoinCount", coinCount);
        coinCountTxt.text =": " + coinCount.ToString();
    }
    public void ActivateCoinDisplay()
    {
        coinDisplay.SetActive(true);
    }
}
