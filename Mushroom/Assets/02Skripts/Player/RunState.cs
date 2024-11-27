using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State<Player>
{
    public override void Enter(Player player)
    {
        Debug.Log("Run");
        player.animator.SetBool("isRun", true);
    }
    public override void Exit(Player player)
    {
        player.animator.SetBool("isRun", false);
    }
    public override void Execute(Player player)
    {
        if (player.playerInput.isStop && !player.playerInput.isRun)
            player.ChangeState(PlayerState.Idle);
        else if (!player.playerInput.isStop && !player.playerInput.isRun)
            player.ChangeState(PlayerState.Walk);
        if (player.playerInput.jump)
            player.ChangeState(PlayerState.Jump);
    }

    public override void FixedExecute(Player player)
    {
        player.playerMovement.Move(false);
    }
}
