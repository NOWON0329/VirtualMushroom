using System.Collections;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float mouseSensitivity = 100f; 
    public Transform player;       

    private float xRotation = 0f;

    [SerializeField] [Range(0.01f, 0.3f)] float shakeRange = 0.05f;
    [SerializeField] private float duration;

    [SerializeField] private bool isDizzy;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float cameraPosX = 0f;
        float cameraPosY = 0f;

        if (isDizzy)
        {
            cameraPosX = Random.value * shakeRange * 2 - shakeRange;
            cameraPosY = Random.value * shakeRange * 2 - shakeRange;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime + cameraPosX;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime + cameraPosY;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        player.Rotate(Vector3.up * mouseX);
    }

    public void ActivateDizzy() => StartCoroutine(CoolDizzy());

    private IEnumerator CoolDizzy()
    {
        isDizzy = true;
        yield return new WaitForSeconds(duration);
        isDizzy = false;
    }
}

