using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System.Security.Cryptography;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private string filePath;

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
        filePath = Path.Combine(Application.streamingAssetsPath, "GameData.json");
    }

    public void GameSave(GameData gameData)
    {
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(filePath, json);
        Debug.Log("게임진행 상황이 저장 되었습니다.");
    }

    public GameData GameLoad()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameData gameData = JsonUtility.FromJson<GameData>(json);
            Debug.Log("저장 데이터를 불러왔습니다.");
            return gameData;
        }
        else
        {
            Debug.Log("저장된 데이터가 없습니다.");
            return null;
        }
    }
}
