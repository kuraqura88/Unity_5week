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
        // ���� ���� ����
        SceneManager.LoadScene("GameScene");
    }

    void OnLoadButtonClicked()
    {
        //���� ������ �ҷ����� ����
    }

    void OnExitButtonClicked()
    {
        // ���� ���� ����
        Application.Quit();
    }
}
