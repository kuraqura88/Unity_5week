using UnityEngine;
using UnityEngine.UI;


public class StageButton : MonoBehaviour
{
    public int stageIndex;
    public Sprite unlockedSprite; // Ȱ��ȭ�� ������ ��������Ʈ
    public Sprite lockedSprite;   // ��Ȱ��ȭ�� ������ ��������Ʈ

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
