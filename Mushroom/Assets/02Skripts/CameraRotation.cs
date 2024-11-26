using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float mouseSensitivity = 100f; // ���콺 ����
    public Transform playerBody;          // �÷��̾� ��ü Transform

    private float xRotation = 0f;         // X�� ȸ���� ���� ����

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // ���콺 Ŀ���� ��� ���·� ����
    }

    void Update()
    {
        // ���콺 �Է� �ޱ�
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // X�� ȸ�� ���� (ī�޶� �������� �ʵ��� ����)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // ī�޶��� X�� ȸ�� ����
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // �÷��̾��� Y�� ȸ�� ����
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

