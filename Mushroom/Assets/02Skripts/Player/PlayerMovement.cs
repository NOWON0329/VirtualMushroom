using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody rigid;

    public float runSpeed = 5f;
    public float walkSpeed = 3f;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody>();
    }


    public void Move(bool walk)
    {
        float speed = walk ? walkSpeed : runSpeed;

        Vector3 moveDir = transform.forward * playerInput.vMove + transform.right * playerInput.hMove;
        moveDir = moveDir.normalized; 

        Vector3 newPosition = rigid.position + moveDir * speed * Time.fixedDeltaTime;
        rigid.MovePosition(newPosition);
    }

    public void Rotate()
    {
        // 필요한 경우 회전 처리 추가
    }
}
