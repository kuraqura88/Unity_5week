using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System.Security.Cryptography;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public int money = 0; // ���� ���
    public int moneyUpgrade = 0; // ��� ���޷� ���׷��̵� ��ġ
    public float criticalUpgrade = 0f; // ũ��Ƽ�� Ȯ��
    public int criticalUpgradeCost = 0; // ũ��Ƽ�� Ȯ�� ���׷��̵� ���
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
