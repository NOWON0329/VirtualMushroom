using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Sprite[] sprites;            // 총 10개의 스프라이트 배열
    public Image displayImage;          // UI Image 컴포넌트 참조

    void Start()
    {
        // 초기 설정: 이미지 비활성화
        displayImage.gameObject.SetActive(false);
    }

    void Update()
    {
        // 키 입력 감지: 0부터 9까지 반복 검사
        for (int i = 0; i <= 9; i++)
        {
            // 버튼을 누르고 있을 때 활성화 (Input.GetKey)
            if (Input.GetKey(KeyCode.Alpha0 + i))
            {
                ShowImage(i);
            }
            // 버튼을 때면 비활성화 (Input.GetKeyUp)
            if (Input.GetKeyUp(KeyCode.Alpha0 + i))
            {
                HideImage();
            }
        }
    }

    // 이미지 활성화 및 스프라이트 변경
    void ShowImage(int index)
    {
        if (sprites.Length == 0) return; // 스프라이트 배열이 비어 있으면 리턴

        if (index >= 0 && index < sprites.Length) // 유효한 인덱스인지 확인
        {
            displayImage.sprite = sprites[index]; // 이미지 변경
            displayImage.gameObject.SetActive(true); // 이미지 활성화
        }
    }

    // 이미지 비활성화
    void HideImage()
    {
        displayImage.gameObject.SetActive(false); // 이미지 비활성화
    }
}
