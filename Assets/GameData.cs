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
            DontDestroyOnLoad(gameObject); // �� ������Ʈ�� �� ��ȯ �� �ı����� ����
        }
        else
        {
            Destroy(gameObject); // �̹� �ν��Ͻ��� �����ϸ� �ı�
        }
    }

    public int score = 0; // ����
    public int money = 0; // ���� ���
    public int moneyUpgrade = 0; // ��� ���޷� ���׷��̵� ��ġ
    public float criticalUpgrade = 0f; // ũ��Ƽ�� Ȯ��
    public int criticalUpgradeCost = 0; // ũ��Ƽ�� Ȯ�� ���׷��̵� ���
    public bool[] isClear = new bool[3];
}
