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
        enhanceButton.onClick.AddListener(() => OnButtonClicked(enhanceBtnObject));
        villageButton.onClick.AddListener(() => OnButtonClicked(villageBtnObject));
        configButton.onClick.AddListener(() => OnButtonClicked(configBtnObject));
    }

    void OnButtonClicked(GameObject targetObject)
    {
        // ��ư Ŭ�� ���� ���
        SoundManager.Instance.PlayButtonClickSound();

        ToggleTargetObject(targetObject);
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
