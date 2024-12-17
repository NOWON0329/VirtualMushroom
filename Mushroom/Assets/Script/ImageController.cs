using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Sprite[] sprites;            // �� 10���� ��������Ʈ �迭
    public Image displayImage;          // UI Image ������Ʈ ����

    void Start()
    {
        // �ʱ� ����: �̹��� ��Ȱ��ȭ
        displayImage.gameObject.SetActive(false);
    }

    void Update()
    {
        // Ű �Է� ����: 0���� 9���� �ݺ� �˻�
        for (int i = 0; i <= 9; i++)
        {
            // ��ư�� ������ ���� �� Ȱ��ȭ (Input.GetKey)
            if (Input.GetKey(KeyCode.Alpha0 + i))
            {
                ShowImage(i);
            }
            // ��ư�� ���� ��Ȱ��ȭ (Input.GetKeyUp)
            if (Input.GetKeyUp(KeyCode.Alpha0 + i))
            {
                HideImage();
            }
        }
    }

    // �̹��� Ȱ��ȭ �� ��������Ʈ ����
    void ShowImage(int index)
    {
        if (sprites.Length == 0) return; // ��������Ʈ �迭�� ��� ������ ����

        if (index >= 0 && index < sprites.Length) // ��ȿ�� �ε������� Ȯ��
        {
            displayImage.sprite = sprites[index]; // �̹��� ����
            displayImage.gameObject.SetActive(true); // �̹��� Ȱ��ȭ
        }
    }

    // �̹��� ��Ȱ��ȭ
    void HideImage()
    {
        displayImage.gameObject.SetActive(false); // �̹��� ��Ȱ��ȭ
    }
}
