using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour, IPointerClickHandler
{
    public UpgradePower upgradePower;

    public RectTransform[] swords;

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 mousePosition = eventData.position;
        RectTransform rectTransform = GetComponent<RectTransform>();

        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition, eventData.pressEventCamera))
        {
            // ※ 스테이지에 따른 변동 필요
            Village();
            Debug.Log("올라감");
        }
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

    private void Village()
    {
        for (int i = 0; i < swords.Length; i++)
        {
            if (swords[i].anchoredPosition.y < 200f)
            {
                swords[i].anchoredPosition += new Vector2(0f, upgradePower.power);
            }
            else
            {
                swords[i].anchoredPosition = new Vector2(0f, 200f);
                //미니 게임 이동
            }
        }
    }
}
