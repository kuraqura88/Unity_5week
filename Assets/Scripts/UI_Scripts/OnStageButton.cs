using UnityEngine;
using UnityEngine.UI;

public class OnStageButton : MonoBehaviour
{
    public GameObject woodImage;
    public GameObject swordImage;
    public GameObject backgroundImage;

    void Start()
    {
        // 버튼에 클릭 이벤트 추가
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClickImage);
    }

    public void OnClickImage()
    {
        // 나무 이미지 활성화, 나머지 이미지는 비활성화
        woodImage.SetActive(true);
        swordImage.SetActive(true);
        backgroundImage.SetActive(true);
    }
}
