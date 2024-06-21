using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("ButtonObject")]
    public GameObject enhanceBtnObject; // 활성화/비활성화할 오브젝트
    public GameObject villageBtnObject;
    public GameObject configBtnObject;

    [Header("Button")]
    public Button enhanceButton; // 토글할 버튼
    public Button villageButton;
    public Button configButton;

    private GameObject currentActiveObject; // 현재 활성화된 오브젝트

    void Start()
    {
        // 버튼에 클릭 이벤트 리스너 추가
        enhanceButton.onClick.AddListener(() => OnButtonClicked(enhanceBtnObject));
        villageButton.onClick.AddListener(() => OnButtonClicked(villageBtnObject));
        configButton.onClick.AddListener(() => OnButtonClicked(configBtnObject));
    }

    void OnButtonClicked(GameObject targetObject)
    {
        // 버튼 클릭 사운드 재생
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
            // 현재 활성화된 오브젝트가 있으면 비활성화
            if (currentActiveObject != null)
            {
                currentActiveObject.SetActive(false);
            }

            // 클릭한 오브젝트를 활성화하고 현재 활성화된 오브젝트로 설정
            targetObject.SetActive(true);
            currentActiveObject = targetObject;
        }
    }
}
