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
        // ��ư�� Ŭ�� �̺�Ʈ ������ �߰�
        startButton.onClick.AddListener(OnStartButtonClicked);
        loadButton.onClick.AddListener(OnLoadButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    void OnStartButtonClicked()
    {
        SoundManager.Instance.PlayButtonClickSound();
        // ���� ���� ����
        SceneManager.LoadScene("GameScene");
    }

    void OnLoadButtonClicked()
    {
        SoundManager.Instance.PlayButtonClickSound();
        //���� ������ �ҷ����� ����
    }

    void OnExitButtonClicked()
    {
        SoundManager.Instance.PlayButtonClickSound();
        // ���� ���� ����
        Application.Quit();
    }
}
