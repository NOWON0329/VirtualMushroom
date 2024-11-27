using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void DoJump()
    {
        Vector3 jumpDir = Vector3.up * player.jumpPower;
        player.rigid.AddForce(jumpDir, ForceMode.Impulse);
    }

    public void DoLandOver()
    {
        player.ChangeState(PlayerState.Idle);
    }
}
