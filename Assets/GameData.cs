using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{

    public int score = 0; // ����
    public int money = 0; // ���� ���
    public int moneyUpgrade = 0; // ��� ���޷� ���׷��̵� ��ġ
    public float criticalUpgrade = 0; // ũ��Ƽ�� Ȯ��
    public int criticalUpgradeCost = 0; // ũ��Ƽ�� Ȯ�� ���׷��̵� ���
    public bool[] isClear = new bool[3];
}
