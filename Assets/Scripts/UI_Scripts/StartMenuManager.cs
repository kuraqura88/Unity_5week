using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public Button startButton;
    public Button loadButton;
    public Button exitButton;

    void Start()
    {
        // 버튼에 클릭 이벤트 리스너 추가
        startButton.onClick.AddListener(OnStartButtonClicked);
        loadButton.onClick.AddListener(OnLoadButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    void OnStartButtonClicked()
    {
        SoundManager.Instance.PlayButtonClickSound();
        // 게임 시작 로직
        SceneManager.LoadScene("GameScene");
    }

    void OnLoadButtonClicked()
    {
        SoundManager.Instance.PlayButtonClickSound();
        //저장 데이터 불러오기 로직
    }

    void OnExitButtonClicked()
    {
        SoundManager.Instance.PlayButtonClickSound();
        // 게임 종료 로직
        Application.Quit();
    }
}
