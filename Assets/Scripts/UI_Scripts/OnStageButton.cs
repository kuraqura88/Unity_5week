using UnityEngine;
using UnityEngine.UI;

public class OnStageButton : MonoBehaviour
{
    public GameObject woodImage;
    public GameObject swordImage;
    public GameObject backgroundImage;

    void Start()
    {
        // ��ư�� Ŭ�� �̺�Ʈ �߰�
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClickImage);
    }

    public void OnClickImage()
    {
        // ���� �̹��� Ȱ��ȭ, ������ �̹����� ��Ȱ��ȭ
        woodImage.SetActive(true);
        swordImage.SetActive(true);
        backgroundImage.SetActive(true);
    }
}
