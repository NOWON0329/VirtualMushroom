using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MushroomManager : MonoBehaviour
{
    public static MushroomManager instance;
    public Player player;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private MushroomBase[] mushroomList;
    public Image displayImage;          // UI Image ������Ʈ ����

    // �̹��� Ȱ��ȭ �� ��������Ʈ ����
    public void ShowImage(int index)
    {
        this.gameObject.transform.position = mushroomList[index].transform.position + new Vector3(0, 0.8f, 0);
        this.gameObject.transform.rotation = player.transform.rotation;
        displayImage.sprite = mushroomList[index].sprite; // �̹��� ����
        displayImage.gameObject.SetActive(true); // �̹��� Ȱ��ȭ
    }

    // �̹��� ��Ȱ��ȭ
    public void HideImage() => displayImage.gameObject.SetActive(false); 
}
