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
        Debug.Log("�������� ��Ȳ�� ���� �Ǿ����ϴ�.");
    }

    public GameData GameLoad()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameData gameData = JsonUtility.FromJson<GameData>(json);
            Debug.Log("���� �����͸� �ҷ��Խ��ϴ�.");
            return gameData;
        }
        else
        {
            Debug.Log("����� �����Ͱ� �����ϴ�.");
            return null;
        }
    }
}
