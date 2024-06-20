using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestDefeatSceneBtn : MonoBehaviour
{
    public Button defeatButton;

    // Start is called before the first frame update
    void Start()
    {
        defeatButton.onClick.AddListener(OnDefeatButtonClicked);
    }

    void OnDefeatButtonClicked()
    {
        SceneManager.LoadScene("DefeatScene");
    }
}
