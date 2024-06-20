using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatButton : MonoBehaviour
{
    public Button retryButton;
    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        retryButton.onClick.AddListener(OnRetryButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    void OnRetryButtonClicked()
    {
        SceneManager.LoadScene("LDH_Scene");
    }

    void OnExitButtonClicked()
    {
        // 게임 종료 로직
        Application.Quit();
    }
}
