using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 이 오브젝트는 씬 전환 시 파괴되지 않음
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 존재하면 파괴
        }
    }

    public int score = 0; // 점수
    public int money = 0; // 모은 골드
    public int moneyUpgrade = 0; // 골드 수급량 업그레이드 수치
    public float criticalUpgrade = 0f; // 크리티컬 확률
    public int criticalUpgradeCost = 0; // 크리티컬 확률 업그레이드 비용
    public bool[] isClear = new bool[3];
}
