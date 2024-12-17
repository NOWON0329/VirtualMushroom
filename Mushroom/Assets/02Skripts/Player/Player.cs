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

    public PlayerInput playerInput { get => _playerInput; set => _playerInput = value; }
    private PlayerInput _playerInput;

    public PlayerMovement playerMovement { get => _playerMovement; set => _playerMovement = value; }
    private PlayerMovement _playerMovement;

    public Animator animator { get => _animator; set => _animator = value; }
    private Animator _animator;

    public Rigidbody rigid { get => _rigid; set => _rigid = value; }
    private Rigidbody _rigid;

    public LandDetector landDetector { get => _landDetector; set => _landDetector = value; }
    private LandDetector _landDetector;

    public PlayerEquip playerEquip { get => _playerEquip; set => _playerEquip = value; }
    private PlayerEquip _playerEquip;

    public CameraRotation cameraRotation { get => _cameraRotation; set => _cameraRotation = value; }
    private CameraRotation _cameraRotation;

    public float jumpPower = 10f;

    public float hunger;
    public float curHunger 
    {
        get=> _curHunger;
        set
        {
            if (value > 100)
                _curHunger = 100;
            else if (value < 0)
                GameOver();
            else
                _curHunger = value;
        }
    }
    private float _curHunger;

    private float curTime;

    protected override void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody>();
        _landDetector = GetComponent<LandDetector>();
        playerEquip = GetComponent<PlayerEquip>();
        _cameraRotation = transform.GetChild(0).GetComponent<CameraRotation>();

        base.Awake();
        curHunger = hunger;
    }

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

        if (curTime > 1)
        {
            curHunger--;
            curTime = 0;
            Debug.Log(curHunger);
        }
        else
            curTime += Time.deltaTime;
    }

    public override void FixedUpdated()
    {
        stateMachine.FixedExecute();
    }

    public void ChangeState(PlayerState newState)
    {
        stateMachine.ChangeState(states[(int)newState]);
    }

    private void GameOver()
    {
        Debug.Log("게임 종료");
    }
}
