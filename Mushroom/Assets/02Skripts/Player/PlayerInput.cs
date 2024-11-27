using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float hMove; 
    public float vMove;
    public bool jump;
    public bool land;
    public bool isRun;
    public bool isStop;

    private void Update()
    {
        hMove = Input.GetAxis("Horizontal");
        vMove = Input.GetAxis("Vertical");
        isStop = hMove == 0 && vMove == 0 ? true : false;
        jump = Input.GetKeyDown(KeyCode.Space);
        isRun = Input.GetKey(KeyCode.LeftShift);
    }
}

