using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; }

    private bool[] stageCleared;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeStages();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadStageData();
    }

    void InitializeStages()
    {
        int stageCount = 3; // 스테이지 개수
        stageCleared = new bool[stageCount];
    }

    public bool IsStageCleared(int stageIndex)
    {
        if (stageIndex < 0 || stageIndex >= stageCleared.Length)
        {
            return false;
        }
        return stageCleared[stageIndex];
    }

    public void ClearStage(int stageIndex)
    {
        if (stageIndex < 0 || stageIndex >= stageCleared.Length)
        {
            return;
        }
        stageCleared[stageIndex] = true;
        SaveStageData();
    }

    void SaveStageData()
    {
        GameData gameData = DataManager.instance.GameLoad() ?? new GameData();
        gameData.isClear = stageCleared;
        DataManager.instance.GameSave(gameData);
    }

    void LoadStageData()
    {
        GameData gameData = DataManager.instance.GameLoad();
        if (gameData != null && gameData.isClear != null)
        {
            stageCleared = gameData.isClear;
        }
    }
}
