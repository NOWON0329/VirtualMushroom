using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum POISONTYPE
{
    NONE, DIZZY, VOMIT, DIE
};
public class MushroomBase : MonoBehaviour
{
    public Player player;
    public bool cooked = false;
    public bool canPick = true;

    public POISONTYPE poisonType;
    public Sprite sprite;

    public void EatMushroom()
    {
        if (!cooked && poisonType != POISONTYPE.NONE)
        {
            GetEffectByPoisonType();
            Destroy(this.gameObject);
            return;
        }

        player.curHunger += 30;

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
            case POISONTYPE.DIE:
                player.curHunger -= 100;
                break;
        }
    }
}
