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
            //���콺 ��ġ
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            //���콺 ��ġ -> ���� ��ǥ
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null 
                && hit.collider.gameObject == gameObject)
            {
                // �� ���������� ���� ���� �ʿ�
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
                //�̴� ���� �̵�
            }
        }
    }
}
