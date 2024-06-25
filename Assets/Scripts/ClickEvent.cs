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
        //�ӽ÷� ����Ƽ �󿡼� �ٽ� �����ϸ� ó������
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

        // 10�� Ŭ���� ������ ��� ����
        if (clickCount >= 10)
        {
            if (GoldManager.Instance != null)
            {
                GoldManager.Instance.AddGold(GoldManager.Instance.goldPerClick); // ��ȭ�� ��� ȹ�淮 ����
            }
            clickCount = 0; // Ŭ�� Ƚ�� �ʱ�ȭ
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
