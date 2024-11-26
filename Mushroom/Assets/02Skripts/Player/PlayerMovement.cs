using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody rigid;
    [SerializeField] private float speed;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        Vector3 moveDir = new Vector3(playerInput.hMove, 0, playerInput.vMove).normalized;
        rigid.AddForce(moveDir * speed, ForceMode.Impulse);
    }
}
