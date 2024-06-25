using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GameData gameData;
    private float saveInterval = 1f;
    private Coroutine autoSaveContinue;

    public int currentScore;
    public int currentMoney;
    public int currentMoneyUpgrade;
    public float currentCriticalUpgrade;
    public int currentCriticalUpgradeCost;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        return;
    }

    private void Start()
    {
        gameData = DataManager.instance.GameLoad();
        if (gameData == null)
        {
            gameData = new GameData();
        }
        else
        {
            gameData.score = currentScore;
            gameData.money = currentMoney;
            gameData.moneyUpgrade = currentMoneyUpgrade;
            gameData.criticalUpgrade = currentCriticalUpgrade;
            gameData.criticalUpgradeCost = currentCriticalUpgradeCost;
        }
        StartAutoSave();
    }

    void OnApplicationQuit()
    {
        SaveGameData();
        DataManager.instance.GameSave(gameData);
    }

    public void StartAutoSave()
    {
        if (autoSaveContinue == null)
        {
            autoSaveContinue = StartCoroutine(AutoSave());
        }
    }

    IEnumerator AutoSave()
    {
        while (true)
        {
            SaveGameData();
            DataManager.instance.GameSave(gameData);
            yield return new WaitForSeconds(saveInterval);
        }
    }

    private void SaveGameData()
    {
        gameData.score = currentScore;
        gameData.money = currentMoney;
        gameData.moneyUpgrade = currentMoneyUpgrade;
        gameData.criticalUpgrade = currentCriticalUpgrade;
        gameData.criticalUpgradeCost = currentCriticalUpgradeCost;
    }
}
