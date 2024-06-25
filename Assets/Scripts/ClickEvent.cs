using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour, IPointerClickHandler
{
    public UpgradePower upgradePower;

    public RectTransform[] swords;

    private int clickCount = 0;
    private int swordIndex;

    private void Start()
    {
        //임시로 유니티 상에서 다시 시작하면 처음부터
        PlayerPrefs.DeleteKey("SwordIndex");
        swordIndex = PlayerPrefs.GetInt("SwordIndex", 0);
        UpdateSword();

        swords[swordIndex].gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 mousePosition = eventData.position;
        RectTransform rectTransform = GetComponent<RectTransform>();

        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition, eventData.pressEventCamera))
        {
            Village();
        }

        clickCount++;

        // 10번 클릭할 때마다 골드 증가
        if (clickCount >= 10)
        {
            if (GoldManager.Instance != null)
            {
                GoldManager.Instance.AddGold(GoldManager.Instance.goldPerClick); // 강화된 골드 획득량 적용
            }
            clickCount = 0; // 클릭 횟수 초기화
        }
    }

    private void Village()
    {
        if (swords[swordIndex].anchoredPosition.y < 200f)
        {
            swords[swordIndex].anchoredPosition += new Vector2(0f, upgradePower.power);
        }
        else
        {
            swords[swordIndex].gameObject.SetActive(false);

            if (swordIndex >= swords.Length - 1)
            {
                SceneManager.LoadScene("Main");
                UpdateSword();
            }
            else
            {
                SceneManager.LoadScene("Map01");
                UpdateSword();
            }
        }
    }

    private void UpdateSword()
    {
        for (int i = 0; i < swords.Length; i++)
        {
            swords[i].gameObject.SetActive(i == swordIndex);
        }
    }
}
