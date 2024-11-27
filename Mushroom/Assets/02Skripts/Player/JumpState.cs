using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State<Player>
{
    float time = 0f;
    public override void Enter(Player player)
    {
        Debug.Log("Jump");
        time = 0f;
        player.animator.SetTrigger("Jump");
    }
    public override void Exit(Player player)
    {
    }
    public override void Execute(Player player)
    {
        time += Time.deltaTime;
        if(time > 1f)
        {
            if (player.rigid.velocity.y < 0 && player.landDetector.CheckGround())
                player.ChangeState(PlayerState.Land);
        }
    }

    public override void FixedExecute(Player player)
    {
        player.playerMovement.Move(true);
    }
}
