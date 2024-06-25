using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
            SceneManager.sceneLoaded += OnSceneLoaded; // 씬 로드 이벤트에 콜백 추가
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 존재하면 파괴
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded; // 씬 로드 이벤트에서 콜백 제거
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬이 로드된 후 goldText를 찾아 설정
        FindGoldTextInScene();
    }

    private void FindGoldTextInScene()
    {
        // goldText를 찾아서 설정
        GameObject goldTextObject = GameObject.FindWithTag("GoldText");
        if (goldTextObject != null)
        {
            goldText = goldTextObject.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogWarning("GoldText 오브젝트를 찾을 수 없습니다.");
        }

        // upgradeCostText도 동일하게 설정
        GameObject upgradeCostTextObject = GameObject.FindWithTag("UpgradeCostText");
        if (upgradeCostTextObject != null)
        {
            upgradeCostText = upgradeCostTextObject.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogWarning("UpgradeCostText 오브젝트를 찾을 수 없습니다.");
        }

        // 텍스트 업데이트
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
            Debug.LogWarning("goldText가 설정되지 않았습니다.");
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
            upgradeCostText.text = upgradeCost.ToString();
        }
        else
        {
            Debug.LogWarning("upgradeCostText가 설정되지 않았습니다.");
        }
    }
}