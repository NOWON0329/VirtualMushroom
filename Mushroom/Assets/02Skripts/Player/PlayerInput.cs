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
    public bool leftMouseClick;
    public bool rightMouseClick;
    public bool ePress;

    private void Update()
    {
        hMove = Input.GetAxis("Horizontal");
        vMove = Input.GetAxis("Vertical");
        isStop = hMove == 0 && vMove == 0 ? true : false;
        jump = Input.GetKeyDown(KeyCode.Space);
        isRun = Input.GetKey(KeyCode.LeftShift);
        leftMouseClick = Input.GetMouseButtonDown(0);
        rightMouseClick = Input.GetMouseButtonDown(1);
        ePress = Input.GetKeyDown(KeyCode.E);
    }
}

