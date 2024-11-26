using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState
{
    Idle, Walk, Run, Jump, Land
}
public class Player : BaseObject
{
    public State<Player>[] states;
    public StateMachine<Player> stateMachine;

    public override void SetUp()
    {
        states = new State<Player>[5];
        states[(int)PlayerState.Idle] = new IdleState();
        states[(int)PlayerState.Walk] = new WalkState();
        states[(int)PlayerState.Run] = new RunState();
        states[(int)PlayerState.Jump] = new JumpState();
        states[(int)PlayerState.Land] = new LandState();

        stateMachine = new StateMachine<Player>();
        stateMachine.SetUp(this, states[(int)PlayerState.Idle]);
    }

    public override void Updated()
    {
        stateMachine.Execute();
    }

    public override void FixedUpdated()
    {
        stateMachine.FixedExecute();
    }

    public void ChangeState(PlayerState newState)
    {
        stateMachine.ChangeState(states[(int)newState]);
    }
}
