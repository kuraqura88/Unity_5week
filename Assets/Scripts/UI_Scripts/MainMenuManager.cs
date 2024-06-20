using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("ButtonObject")]
    public GameObject enhanceBtnObject; // Ȱ��ȭ/��Ȱ��ȭ�� ������Ʈ
    public GameObject villageBtnObject;
    public GameObject configBtnObject;

    [Header("Button")]
    public Button enhanceButton; // ����� ��ư
    public Button villageButton;
    public Button configButton;

    private GameObject currentActiveObject; // ���� Ȱ��ȭ�� ������Ʈ

    void Start()
    {
        // ��ư�� Ŭ�� �̺�Ʈ ������ �߰�
        enhanceButton.onClick.AddListener(() => ToggleTargetObject(enhanceBtnObject));
        villageButton.onClick.AddListener(() => ToggleTargetObject(villageBtnObject));
        configButton.onClick.AddListener(() => ToggleTargetObject(configBtnObject));
    }

    void ToggleTargetObject(GameObject targetObject)
    {
        if (currentActiveObject == targetObject)
        {
            targetObject.SetActive(false);
            currentActiveObject = null;
        }
        else
        {
            // ���� Ȱ��ȭ�� ������Ʈ�� ������ ��Ȱ��ȭ
            if (currentActiveObject != null)
            {
                currentActiveObject.SetActive(false);
            }

            // Ŭ���� ������Ʈ�� Ȱ��ȭ�ϰ� ���� Ȱ��ȭ�� ������Ʈ�� ����
            targetObject.SetActive(true);
            currentActiveObject = targetObject;
        }
    }
}
