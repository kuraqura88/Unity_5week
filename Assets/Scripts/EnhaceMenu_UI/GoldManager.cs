using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance { get; private set; }

    public int gold = 0;
    public int goldPerClick = 10; // �⺻ ��� ȹ�淮
    public TextMeshProUGUI goldText;

    // ���׷��̵� ��� ����
    public int upgradeCost = 50;
    public TextMeshProUGUI upgradeCostText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ������Ʈ�� �� ��ȯ �� �ı����� ����
            SceneManager.sceneLoaded += OnSceneLoaded; // �� �ε� �̺�Ʈ�� �ݹ� �߰�
        }
        else
        {
            Destroy(gameObject); // �̹� �ν��Ͻ��� �����ϸ� �ı�
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded; // �� �ε� �̺�Ʈ���� �ݹ� ����
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ���� �ε�� �� goldText�� ã�� ����
        FindGoldTextInScene();
    }

    private void FindGoldTextInScene()
    {
        // goldText�� ã�Ƽ� ����
        GameObject goldTextObject = GameObject.FindWithTag("GoldText");
        if (goldTextObject != null)
        {
            goldText = goldTextObject.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogWarning("GoldText ������Ʈ�� ã�� �� �����ϴ�.");
        }

        // upgradeCostText�� �����ϰ� ����
        GameObject upgradeCostTextObject = GameObject.FindWithTag("UpgradeCostText");
        if (upgradeCostTextObject != null)
        {
            upgradeCostText = upgradeCostTextObject.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogWarning("UpgradeCostText ������Ʈ�� ã�� �� �����ϴ�.");
        }

        // �ؽ�Ʈ ������Ʈ
        UpdateGoldText();
        UpdateUpgradeCostText();
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

    public void UpdateGoldText()
    {
        if (goldText != null)
        {
            goldText.text = gold.ToString();
        }
        else
        {
            Debug.LogWarning("goldText�� �������� �ʾҽ��ϴ�.");
        }
    }

    // ��� ȹ�淮�� ������Ű�� �޼���
    public void UpgradeGoldPerClick(int amount)
    {
        goldPerClick += amount;
        UpdateUpgradeCostText();
    }

    public void UpdateUpgradeCostText()
    {
        if (upgradeCostText != null)
        {
            upgradeCostText.text = upgradeCost.ToString();
        }
        else
        {
            Debug.LogWarning("upgradeCostText�� �������� �ʾҽ��ϴ�.");
        }
    }
}