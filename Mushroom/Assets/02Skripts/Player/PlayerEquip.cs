using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    private Player player;
    public ObjectSelector objectSelector;
    [SerializeField] private Transform equipPos;
    private Interaction curInteraction;


    public MushroomBase equipMushroom { 
        get => _equipMushroom; 
        set
        {
            _equipMushroom = value;
            isGrab = true;
        } 
    }
    private MushroomBase _equipMushroom;

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

        if(player.playerInput.ePress)
        {
            SetCurInteraction();
        }
    }

    public void EquipMushroom()
    {
        if(objectSelector.targetObject != null && objectSelector.targetObject.GetComponent<MushroomBase>())
        {
            DropMushroom();

            equipMushroom = objectSelector.targetObject.GetComponent<MushroomBase>();

            if (equipMushroom.canPick)
            {
                if (equipMushroom != null)
                {
                    Destroy(equipMushroom.GetComponent<Rigidbody>());
                    equipMushroom.transform.position = equipPos.position;
                    equipMushroom.transform.rotation = Quaternion.Euler(0, 0, 0);
                    equipMushroom.transform.SetParent(this.transform);
                }
            }
            else
            {
                equipMushroom = null;
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

    public void SetCurInteraction()
    {
        if (objectSelector.targetObject != null && objectSelector.targetObject.GetComponent<Interaction>())
        {
            if (objectSelector.targetObject.GetComponent<DishInteraction>())
            {
                EatMushroom();
                return;
            }
            if (equipMushroom == null)
                return;
            if (equipMushroom.cooked)
                return;

            curInteraction = objectSelector.targetObject.GetComponent<Interaction>();
            if (curInteraction.isInteracting)
            {
                curInteraction = null;
                return;
            }

            if (curInteraction != null)
            {
                Destroy(equipMushroom.GetComponent<Rigidbody>());
                equipMushroom.gameObject.transform.SetParent(null);
                equipMushroom.transform.position = curInteraction.cookPos.position;
                equipMushroom.transform.rotation = Quaternion.Euler(0, 0, 0);

                CookMushroom();
                isGrab = false;
                equipMushroom = null;
                curInteraction = null;
                return;
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
        curInteraction.Interact(equipMushroom.gameObject);
    }
}
