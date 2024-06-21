using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour
{
    public UpgradePower upgradePower;

    //public GameObject sword1;
    public GameObject[] swords;

    public void OnMouse(InputValue value)
    {
        if (value.isPressed)
        {
            //마우스 위치
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            //마우스 위치 -> 월드 좌표
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null 
                && hit.collider.gameObject == gameObject)
            {
                // ※ 스테이지에 따른 변동 필요
                Village();
            }
        }
    }

    private void Village()
    {
        for (int i = 0; i < swords.Length; i++)
        {
            if (swords[i].transform.position.y < 0f)
            {
                swords[i].transform.position += new Vector3(0f, upgradePower.power, 0f);
            }
            else
            {
                swords[i].transform.position = new Vector3(0f, 0f, 0f);
                //미니 게임 이동
            }
        }
    }
}
