using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float mouseSensitivity = 100f; // 마우스 감도
    public Transform playerBody;          // 플레이어 몸체 Transform

    private float xRotation = 0f;         // X축 회전값 저장 변수

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서를 잠금 상태로 설정
    }

    void Update()
    {
        // 마우스 입력 받기
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // X축 회전 제한 (카메라가 뒤집히지 않도록 제한)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // 카메라의 X축 회전 적용
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 플레이어의 Y축 회전 적용
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

