using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public GoldManager goldManager;
    public Button upgradeButton;

    private Button button;


    private void Awake()
    {
        goldManager = GoldManager.Instance;
    }

    private void Start()
    {
        if (upgradeButton != null)
        {
            upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
        }
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);

        // 초기 업그레이드 비용 텍스트 업데이트
        if (goldManager != null)
        {
            goldManager.UpdateUpgradeCostText();
        }
    }

    private void OnUpgradeButtonClick()
    {
        if (goldManager != null)
        {
            if (goldManager.SpendGold(goldManager.upgradeCost))
            {
                goldManager.UpgradeGoldPerClick(10); // 골드 획득량을 10만큼 증가
                goldManager.upgradeCost += 50; // 업그레이드 비용 증가
                goldManager.UpdateUpgradeCostText(); // 업그레이드 비용 텍스트 업데이트
            }
        }
    }

    void OnButtonClick()
    {
        SoundManager.Instance.PlayButtonClickSound();
    }
}