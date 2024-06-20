using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePower : MonoBehaviour
{
    private int gold = 1000;
    private int upgradeCost = 1000;
    public int power = 1;

    public Button upgradeButton;
    
    //보유중인 골드 텍스트 연결

    private void Start()
    {
        upgradeButton.onClick.AddListener(Upgrade);
    }

    public void Upgrade()
    {
        if (gold >= upgradeCost)
        {
            gold -= upgradeCost;
            power++;
        }
    }
}
