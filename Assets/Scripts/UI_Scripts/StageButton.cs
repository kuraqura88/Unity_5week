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
    }

    void OnButtonClick()
    {
        SoundManager.Instance.PlayButtonClickSound();
    }
}
