using UnityEngine;
using UnityEngine.UI;

public class UpgradePower : MonoBehaviour
{
    private int gold = GoldManager.Instance.gold;
    private int upgradeCost = 10;
    public float power;

    public Button upgradeButton;

    //�������� ��� �ؽ�Ʈ ����

    private void Awake()
    {
        power = 3f;
    }

    private void Start()
    {
        upgradeButton.onClick.AddListener(Upgrade);
    }

    public void Upgrade()
    {
        if (gold >= upgradeCost)
        {
            gold -= upgradeCost;
            power += 3f;
        }
    }
}
