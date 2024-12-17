using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum POISONTYPE
{
    NONE, DIZZY, VOMIT
};
public class MushroomBase : MonoBehaviour
{
    public Player player;
    public bool cooked = false;
    public bool canPick = true;

    public POISONTYPE poisonType;

    public void EatMushroom()
    {
        if (!cooked && poisonType != POISONTYPE.NONE)
        {
            GetEffectByPoisonType();
            return;
        }

        player.curHunger += 50;

        Destroy(this.gameObject);
    }

    public void GetEffectByPoisonType()
    {
        switch (poisonType)
        {
            case POISONTYPE.NONE:
                break;
            case POISONTYPE.DIZZY:
                player.cameraRotation.ActivateDizzy();
                break;
            case POISONTYPE.VOMIT:
                player.curHunger -= 30;
                break;
        }
    }
}
