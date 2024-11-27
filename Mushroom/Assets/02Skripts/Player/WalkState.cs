using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State<Player>
{
    public override void Enter(Player player)
    {
        Debug.Log("Walk");
        player.animator.SetBool("isWalk", true);
    }
    public override void Exit(Player player)
    {
        player.animator.SetBool("isWalk", false);
    }
    public override void Execute(Player player)
    {
        if (player.playerInput.isRun)
            player.ChangeState(PlayerState.Run);
        else if (player.playerInput.isStop)
            player.ChangeState(PlayerState.Idle);
        
        if(player.playerInput.jump)
            player.ChangeState(PlayerState.Jump);   
    }

    public override void FixedExecute(Player player)
    {
        player.playerMovement.Move(true);
    }
}
