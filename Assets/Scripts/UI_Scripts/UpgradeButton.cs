using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public GoldManager goldManager;
    public Button upgradeButton;

    private Button button;

    private void Start()
    {
        if (upgradeButton != null)
        {
            upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
        }
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnUpgradeButtonClick()
    {
        if (goldManager != null)
        {
            if (goldManager.SpendGold(goldManager.upgradeCost))
            {
                goldManager.UpgradeGoldPerClick(10); // ��� ȹ�淮�� 10��ŭ ����
                goldManager.upgradeCost += 50; // ���׷��̵� ��� ����
                goldManager.UpdateUpgradeCostText(); // ���׷��̵� ��� �ؽ�Ʈ ������Ʈ
            }
        }
    }

    void OnButtonClick()
    {
        SoundManager.Instance.PlayButtonClickSound();
    }
}