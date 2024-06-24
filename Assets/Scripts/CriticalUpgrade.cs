using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CriticalUpgrade : MonoBehaviour
{
    public UpgradePower upgradePower;

    public TextMeshProUGUI criticalText;

    private int upgradeCost = 10;
    public float critical = 0f;

    public void Upgrade()
    {
        if (GoldManager.Instance.gold >= upgradeCost)
        {
            critical += 2f;
            upgradeCost += 5;
            GoldManager.Instance.SpendGold(upgradeCost);
            GoldManager.Instance.UpdateGoldText();
        }
        else if (critical >= 100)
        {
            Debug.Log("크리티컬 확률이 이미 100%입니다.");
        }
        SaveData();
    }

    public bool CriticalHit()
    {
        float randomValue = Random.Range(0, 100f);
        return randomValue < critical;
    }

    public float CriticalDamage()
    {
        float baseDamage = upgradePower.power;
        if (CriticalHit())
        {
            baseDamage *= 2;
        }
        return baseDamage;
    }

    private void SaveData()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.currentCriticalUpgrade = critical;
            GameManager.instance.currentCriticalUpgradeCost = upgradeCost;
        }
    }
}
