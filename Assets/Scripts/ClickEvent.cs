using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour
{
    public int count = 0;

    public UpgradePower upgradePower;

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
                count += upgradePower.power;
                Debug.Log(count);
            }
        }
    }

    //검 뽑고 난 뒤 애니메이션이나 씬 이동
}
