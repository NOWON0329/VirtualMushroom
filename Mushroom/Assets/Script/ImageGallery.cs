using UnityEngine;
using UnityEngine.UI;

public class ImageGallery : MonoBehaviour
{
    public Player player;
    public Sprite[] sprites;           // ��������Ʈ �迭 (�ѱ� �̹������� ���⿡ �Ҵ�)
    public Image displayImage;         // UI Image ������Ʈ ����
    private int currentIndex = 0;      // ���� ǥ�õǴ� ��������Ʈ�� �ε���

    void Start()
    {
        if (sprites.Length > 0)
        {
            displayImage.sprite = sprites[currentIndex]; // �ʱ� �̹��� ����
        }
    }

    void Update()
    {
        // ���� ����Ű �Է� �� ���� �̹���
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ShowPreviousImage();
        }
        // ������ ����Ű �Է� �� ���� �̹���
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
        if (sprites.Length == 0) return; // ��������Ʈ�� ������ �ƹ��͵� ���� ����

        currentIndex--; // �ε��� ����
        if (currentIndex < 0)
        {
            currentIndex = sprites.Length - 1; // ù �̹������� �ڷ� ���� ������ �̹����� ��ȯ
        }
        displayImage.sprite = sprites[currentIndex];
    }

    void ShowNextImage()
    {
        if (sprites.Length == 0) return;

        currentIndex++; // �ε��� ����
        if (currentIndex >= sprites.Length)
        {
            currentIndex = 0; // ������ �̹������� ������ ���� ù �̹����� ��ȯ
        }
        displayImage.sprite = sprites[currentIndex];
    }
}
