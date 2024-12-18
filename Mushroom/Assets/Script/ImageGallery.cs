using UnityEngine;
using UnityEngine.UI;

public class ImageGallery : MonoBehaviour
{
    public Player player;
    public Sprite[] sprites;           // 스프라이트 배열 (넘길 이미지들을 여기에 할당)
    public Image displayImage;         // UI Image 컴포넌트 참조
    private int currentIndex = 0;      // 현재 표시되는 스프라이트의 인덱스

    void Start()
    {
        if (sprites.Length > 0)
        {
            displayImage.sprite = sprites[currentIndex]; // 초기 이미지 설정
        }
    }

    void Update()
    {
        // 왼쪽 방향키 입력 → 이전 이미지
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ShowPreviousImage();
        }
        // 오른쪽 방향키 입력 → 다음 이미지
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ShowNextImage();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            displayImage.gameObject.SetActive(false);
            player.gameStart = true;
        }
            
    }

    void ShowPreviousImage()
    {
        if (sprites.Length == 0) return; // 스프라이트가 없으면 아무것도 하지 않음

        currentIndex--; // 인덱스 감소
        if (currentIndex < 0)
        {
            currentIndex = sprites.Length - 1; // 첫 이미지에서 뒤로 가면 마지막 이미지로 순환
        }
        displayImage.sprite = sprites[currentIndex];
    }

    void ShowNextImage()
    {
        if (sprites.Length == 0) return;

        currentIndex++; // 인덱스 증가
        if (currentIndex >= sprites.Length)
        {
            currentIndex = 0; // 마지막 이미지에서 앞으로 가면 첫 이미지로 순환
        }
        displayImage.sprite = sprites[currentIndex];
    }
}
