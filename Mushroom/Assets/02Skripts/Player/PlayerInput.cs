using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public float hMove { get => _hMove; set => _hMove = value; }
    private float _hMove;
    public float vMove { get => _vMove; set => _vMove = value; }
    private float _vMove;

    public bool jump;
    public bool land;
    public bool isRun;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        hMove = Input.GetAxis("Horizontal");
        vMove = Input.GetAxis("Vertical");
        jump = Input.GetKeyDown(KeyCode.Space);
        
    }

    private void FixedUpdate()
    {
        playerMovement.Move();
    }
}
