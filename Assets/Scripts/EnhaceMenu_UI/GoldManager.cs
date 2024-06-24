using UnityEngine;
using TMPro;

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance { get; private set; }

    public int gold = 0;
    public int goldPerClick = 10; // 기본 골드 획득량
    public TextMeshProUGUI goldText;

    // 업그레이드 비용 변수
    public int upgradeCost = 50;
    public TextMeshProUGUI upgradeCostText;

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

    public void AddGold(int amount)
    {
        gold += amount;
        UpdateGoldText();
    }

    public bool SpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            UpdateGoldText();
            return true;
        }
        return false;
    }

    private void UpdateGoldText()
    {
        if (goldText != null)
        {
            goldText.text = "" + gold.ToString();
        }
    }

    // 골드 획득량을 증가시키는 메서드
    public void UpgradeGoldPerClick(int amount)
    {
        goldPerClick += amount;
        UpdateUpgradeCostText();
    }

    public void UpdateUpgradeCostText()
    {
        if (upgradeCostText != null)
        {
            upgradeCostText.text = "" + upgradeCost.ToString();
        }
    }
}
