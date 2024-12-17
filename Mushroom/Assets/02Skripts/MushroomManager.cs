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
    public Image displayImage;          // UI Image 컴포넌트 참조

    // 이미지 활성화 및 스프라이트 변경
    public void ShowImage(int index)
    {
        this.gameObject.transform.position = mushroomList[index].transform.position + new Vector3(0, 0.8f, 0);
        this.gameObject.transform.rotation = player.transform.rotation;
        displayImage.sprite = mushroomList[index].sprite; // 이미지 변경
        displayImage.gameObject.SetActive(true); // 이미지 활성화
    }

    // 이미지 비활성화
    public void HideImage() => displayImage.gameObject.SetActive(false); 
}
