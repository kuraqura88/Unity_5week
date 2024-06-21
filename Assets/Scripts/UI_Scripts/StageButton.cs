using UnityEngine;
using UnityEngine.UI;


public class StageButton : MonoBehaviour
{
    public int stageIndex;
    public Sprite unlockedSprite; // 활성화된 상태의 스프라이트
    public Sprite lockedSprite;   // 비활성화된 상태의 스프라이트

    private Button button;
    private Image buttonImage;

    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
        UpdateButtonState();
        button.onClick.AddListener(OnButtonClick);
    }

    void UpdateButtonState()
    {
        if (stageIndex > 0 && !StageManager.Instance.IsStageCleared(stageIndex - 1))
        {
            button.interactable = false;
            buttonImage.sprite = lockedSprite;
        }
        else
        {
            button.interactable = true;
            buttonImage.sprite = unlockedSprite;
        }
    }

    void OnButtonClick()
    {
        SoundManager.Instance.PlayButtonClickSound();
    }
}
