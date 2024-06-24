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
    }

    private void Update()
    {
        StartAutoSave();
    }

    void OnApplicationQuit()
    {
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
            gameData.GameScore = currentScore;
            gameData.GameMoney = currentMoney;
            yield return new WaitForSeconds(saveInterval);
        }
    }
}
