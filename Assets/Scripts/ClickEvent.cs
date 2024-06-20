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
            //���콺 ��ġ
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            //���콺 ��ġ -> ���� ��ǥ
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

    //�� �̰� �� �� �ִϸ��̼��̳� �� �̵�
}
