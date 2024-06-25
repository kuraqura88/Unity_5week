using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CriticalUpgrade : MonoBehaviour
{
    public static CriticalUpgrade instance;

    public TextMeshProUGUI criticalText;
    public TextMeshProUGUI criticalUpgradeText;

    public int upgradeCost = 10;
    public float critical = 0f;

    private Button button;

    private void Awake()
    {
        LoadCritical();

        GameObject criticalTextObject = GameObject.FindWithTag("CriticalText");
        if (criticalTextObject != null)
        {
            criticalText = criticalTextObject.GetComponent<TextMeshProUGUI>();
        }

        GameObject criticalUpgradeTextObject = GameObject.FindWithTag("CriticalUpgradeCostText");
        if (criticalUpgradeTextObject != null)
        {
            criticalUpgradeText = criticalUpgradeTextObject.GetComponent<TextMeshProUGUI>();
        }

        UpdateCriticalText();
        UpdateUpgradeCostText();
    }

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    public void Upgrade()
    {
        if (GoldManager.Instance.gold >= upgradeCost && critical < 100)
        {
            GoldManager.Instance.SpendGold(upgradeCost);
            GoldManager.Instance.UpdateGoldText();

            critical += 2f;
            upgradeCost += 5;

            UpdateCriticalText();
            UpdateUpgradeCostText();
            SaveCritical();
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
        float baseDamage = DataManager.instance.power;
        if (CriticalHit())
        {
            baseDamage *= 2;
        }
        return baseDamage;
    }

    public void UpdateCriticalText()
    {
        if (criticalText != null)
        {
            criticalText.text = critical.ToString() + "%";
        }
    }

    public void UpdateUpgradeCostText()
    {
        if (criticalUpgradeText != null)
        {
            criticalUpgradeText.text = upgradeCost.ToString();
        }
    }

    private void SaveCritical()
    {
        DataManager.instance.criticalUpgrade = critical;
        DataManager.instance.criticalUpgradeCost = upgradeCost;
    }

    private void LoadCritical()
    {
        if (DataManager.instance.criticalUpgrade >= 0f && DataManager.instance.criticalUpgradeCost >= 0)
        {
            critical = DataManager.instance.criticalUpgrade;
            upgradeCost = DataManager.instance.criticalUpgradeCost;
        }
    }

    void OnButtonClick()
    {
        SoundManager.Instance.PlayButtonClickSound();
    }
}