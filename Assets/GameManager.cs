using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
        DataManager.instance.GameLoad();
    }

    void OnApplicationQuit()
    {
        DataManager.instance.GameSave();
    }
}
