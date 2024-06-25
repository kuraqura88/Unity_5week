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
        DataManager.instance.isClear = stageCleared;
        DataManager.instance.GameSave();
    }
}
