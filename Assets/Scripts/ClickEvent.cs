using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour, IPointerClickHandler
{
    public UpgradePower upgradePower;
    public CriticalUpgrade criticalUpgrade;

    public RectTransform[] swords;

    private int clickCount = 0;

    private void Start()
    {
        DataManager.instance.GameLoad();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 mousePosition = eventData.position;
        RectTransform rectTransform = GetComponent<RectTransform>();

        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition, eventData.pressEventCamera))
        {
            Village();
            Debug.Log("�ö�");
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
        for (int i = 0; i < swords.Length; i++)
        {
            if (swords[i].anchoredPosition.y < 200f)
            {
                swords[i].anchoredPosition += new Vector2(0f, upgradePower.power);
                swords[i].anchoredPosition += new Vector2(0f, criticalUpgrade.CriticalDamage());
            }
            else
            {
                if (swords[0].anchoredPosition.y >= 200f)
                {
                    //2�� �� �̴� ���� �̵�
                    Invoke("GameSceneChange1", 2);
                    swords[0].gameObject.SetActive(false);
                    swords[1].gameObject.SetActive(true);
                }

                if (swords[1].anchoredPosition.y >= 200f)
                {
                    //2�� �� �̴� ���� �̵�
                    Invoke("GameSceneChange1", 2);
                    swords[1].gameObject.SetActive(false);
                    swords[2].gameObject.SetActive(true);
                }

                if (swords[2].anchoredPosition.y >= 200f)
                {
                    //2�� �� �̴� ���� �̵�
                    Invoke("GameSceneChange2", 2);
                }
            }
        }
    }

    private void GameSceneChange1()
    {
        SceneManager.LoadScene("Main");
    }
    
    private void GameSceneChange2()
    {
        SceneManager.LoadScene("Map01");
    }
    
    //public void OnMouse(InputValue value)
    //{
    //    if (value.isPressed)
    //    {
    //        Debug.Log("Ŭ����");
    //        //���콺 ��ġ
    //        Vector2 mousePosition = Mouse.current.position.ReadValue();
    //        //���콺 ��ġ -> ���� ��ǥ
    //        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
    //        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

    //        if (hit.collider != null 
    //            && hit.collider.gameObject == gameObject)
    //        {
    //            // �� ���������� ���� ���� �ʿ�
    //            Village();
    //            Debug.Log("�ö�");

    //        }
    //    }
    //}
}
