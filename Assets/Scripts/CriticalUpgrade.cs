using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CriticalUpgrade : MonoBehaviour
{
    public static CriticalUpgrade instance;

    public UpgradePower upgradePower;
    public TextMeshProUGUI criticalText;

    public int upgradeCost = 10;
    public float critical = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
}
