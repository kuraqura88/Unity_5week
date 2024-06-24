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
            Debug.Log("올라감");
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
                    //2초 뒤 미니 게임 이동
                    Invoke("GameSceneChange1", 2);
                    swords[0].gameObject.SetActive(false);
                    swords[1].gameObject.SetActive(true);
                }

                if (swords[1].anchoredPosition.y >= 200f)
                {
                    //2초 뒤 미니 게임 이동
                    Invoke("GameSceneChange1", 2);
                    swords[1].gameObject.SetActive(false);
                    swords[2].gameObject.SetActive(true);
                }

                if (swords[2].anchoredPosition.y >= 200f)
                {
                    //2초 뒤 미니 게임 이동
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
    //        Debug.Log("클릭함");
    //        //마우스 위치
    //        Vector2 mousePosition = Mouse.current.position.ReadValue();
    //        //마우스 위치 -> 월드 좌표
    //        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
    //        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

    //        if (hit.collider != null 
    //            && hit.collider.gameObject == gameObject)
    //        {
    //            // ※ 스테이지에 따른 변동 필요
    //            Village();
    //            Debug.Log("올라감");

    //        }
    //    }
    //}
}
