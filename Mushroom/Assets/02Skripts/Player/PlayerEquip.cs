using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    private Player player;
    public ObjectSelector objectSelector;
    [SerializeField] private Transform equipPos;

    private MushroomBase equipMushroom { 
        get => _equipMushroom; 
        set
        {
            _equipMushroom = value;
            isGrab = true;
        } 
    }
    public MushroomBase _equipMushroom;

    public bool isGrab = false;

    private void Awake()
    {
        player = this.GetComponent<Player>();
    }

    private void Update()
    {
        if (player.playerInput.leftMouseClick)
        {
            EquipMushroom();
        }
    }

    public void EquipMushroom()
    {
        if(objectSelector.targetObject != null)
        {
            GameObject mushroom = objectSelector.targetObject;
            equipMushroom = mushroom.GetComponent<MushroomBase>();
            if(equipMushroom != null)
            {
                mushroom.transform.position = equipPos.position;
                mushroom.transform.parent = this.transform;
            }
        }
    }

    public void EatMushroom()
    {
        isGrab = false;
        equipMushroom.EatMushroom();
    }

    public void CookMushroom()
    {
        isGrab = false;
        equipMushroom.CookMushroom();
    }
}
