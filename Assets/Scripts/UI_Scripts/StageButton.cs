using UnityEngine;
using UnityEngine.UI;


public class StageButton : MonoBehaviour
{
    public int stageIndex;
    public int buttonIndex;

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        button.onClick.AddListener(() => SetSwordIndex(buttonIndex));
    }

    void OnButtonClick()
    {
        SoundManager.Instance.PlayButtonClickSound();
    }
    private void SetSwordIndex(int index)
    {
        PlayerPrefs.SetInt("SwordIndex", index);
        PlayerPrefs.Save();
    }
}
