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
        else if (player.playerInput.rightMouseClick)
        {
            DropMushroom();
        }
    }

    public void EquipMushroom()
    {
        if(objectSelector.targetObject != null && objectSelector.targetObject.GetComponent<MushroomBase>())
        {
            DropMushroom();

            equipMushroom = objectSelector.targetObject.GetComponent<MushroomBase>();
            if(equipMushroom != null)
            {
                Destroy(equipMushroom.GetComponent<Rigidbody>());
                equipMushroom.transform.position = equipPos.position;
                equipMushroom.transform.rotation = Quaternion.Euler(0, 0, 0);
                equipMushroom.transform.SetParent(this.transform);
            }
        }
    }

    public void DropMushroom()
    {
        if (equipMushroom != null)
        {
            equipMushroom.gameObject.AddComponent<Rigidbody>();
            equipMushroom.gameObject.transform.SetParent(null);
            equipMushroom = null;
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
