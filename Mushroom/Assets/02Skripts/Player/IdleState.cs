using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State<Player>
{
    public override void Enter(Player player)
    {
        Debug.Log("Idle");
    }
    public override void Exit(Player player)
    {
    }
    public override void Execute(Player player)
    {
        if (!player.playerInput.isStop)
            player.ChangeState(PlayerState.Walk);

        if (player.playerInput.jump)
            player.ChangeState(PlayerState.Jump);
    }
    public override void FixedExecute(Player player)
    {
    }
}
