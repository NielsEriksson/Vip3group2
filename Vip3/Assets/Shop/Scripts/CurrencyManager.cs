using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;
    [HideInInspector] public int starCount { get; private set; }
    [HideInInspector] public int coinCount { get; private set; }

    public TMP_Text starCountTxt;
    public TMP_Text coinCountTxt;

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
        starCount = PlayerPrefs.GetInt("StarCount", 0);
        coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        starCountTxt.text = ": " + starCount.ToString();
        coinCountTxt.text = ": " + coinCount.ToString();
    }

    public bool CanAfford(int price, string currencyType) //send in either "Star" or "Coin" as string when using this method
    {
        if (currencyType == "Star" && starCount - price >= 0) return true;
        else if (currencyType == "Coin" && coinCount - price >= 0) return true;
        else return false;
    }

    public void ChangeStarCount(int amount)
    {
        starCount+= amount;
        PlayerPrefs.SetInt("StarCount", starCount);
        Debug.Log(starCount);
        starCountTxt.text = ": " + starCount.ToString();
    }

    public void ChangeCoinCount(int amount)
    {
        coinCount+=amount;
        PlayerPrefs.SetInt("CoinCount", coinCount);
        coinCountTxt.text =": " + coinCount.ToString();
    }
}
