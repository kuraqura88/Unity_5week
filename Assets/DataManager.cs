using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System.Security.Cryptography;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public int money = 0; // 모은 골드
    public int moneyUpgrade = 0; // 골드 수급량 업그레이드 수치
    public float criticalUpgrade = 0f; // 크리티컬 확률
    public int criticalUpgradeCost = 0; // 크리티컬 확률 업그레이드 비용
    public bool[] isClear = new bool[3];

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameSave()
    {
        PlayerPrefs.SetInt("Money", GoldManager.Instance.gold);
        PlayerPrefs.SetInt("MoneyUpgrade", GoldManager.Instance.upgradeCost);
        PlayerPrefs.SetFloat("CriticalUpgrade", CriticalUpgrade.instance.critical);
        PlayerPrefs.SetInt("CriticalUpgradeCost", CriticalUpgrade.instance.upgradeCost);
        PlayerPrefs.Save();
    }
    
    public void GameLoad()
    {
        GoldManager.Instance.gold = PlayerPrefs.GetInt("Money", 0);
        GoldManager.Instance.upgradeCost = PlayerPrefs.GetInt("MoneyUpgrade", 0);
        CriticalUpgrade.instance.critical = PlayerPrefs.GetFloat("CriticalUpgrade", 0f);
        CriticalUpgrade.instance.upgradeCost = PlayerPrefs.GetInt("CriticalUpgradeCost", 0);
    }
}
