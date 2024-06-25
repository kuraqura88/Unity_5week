using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePower : MonoBehaviour
{
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI powerUpgradeCostText;

    public Button upgradeButton;

    private int upgradeCost = 10;
    public float power;

    private void Awake()
    {
        power = 3f;
        UpdatePowerText();
        UpdateUpgradeCostText();
    }

    private void Start()
    {
        if (upgradeButton != null)
        {
            upgradeButton.onClick.AddListener(Upgrade);
        }
        upgradeButton = GetComponent<Button>();
        upgradeButton.onClick.AddListener(OnButtonClick);
    }

    public void Upgrade()
    {
        if (GoldManager.Instance.gold >= upgradeCost)
        {
            GoldManager.Instance.SpendGold(upgradeCost);
            GoldManager.Instance.UpdateGoldText();

            power += 3f;
            upgradeCost += 5;

            UpdatePowerText();
            UpdateUpgradeCostText();
        }
    }

    public void UpdatePowerText()
    {
        if (powerText != null)
        {
            powerText.text = power.ToString();
        }
    }

    public void UpdateUpgradeCostText()
    {
        if (powerUpgradeCostText != null)
        {
            powerUpgradeCostText.text = upgradeCost.ToString();
        }
    }

    void OnButtonClick()
    {
        SoundManager.Instance.PlayButtonClickSound();
    }
}
