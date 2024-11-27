using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandState : State<Player>
{
    public override void Enter(Player player)
    {
        Debug.Log("Land");
        player.animator.SetTrigger("Land");
    }
    public override void Exit(Player player)
    {
        player.playerInput.land = false;
    }
    public override void Execute(Player player)
    {

    }

    public override void FixedExecute(Player player)
    {
    }
}
