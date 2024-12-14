using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum POISONTYPE
{
    NONE, DIZZY, VOMIT, BLIND
};
public enum COOKTYPE
{
    NONE, BOIL, ROAST
};
public class MushroomBase : MonoBehaviour
{
    public bool cooked = false;
    public bool canPick = true;

    public POISONTYPE poisonType;
    public COOKTYPE cookType;

    public virtual void EatMushroom()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (renderer.material.color.Equals(Color.green))
            GetEffectByPoisonType();
        else
            Debug.Log("문제 없음");
        Destroy(this.gameObject);
    }
    public virtual bool CookMushroom(COOKTYPE cT)
    {
        if (cT.Equals(cookType))
            return true;
        else
            return false;
    }
    public void GetEffectByPoisonType()
    {
        switch (poisonType)
        {
            case POISONTYPE.NONE:
                break;
            case POISONTYPE.DIZZY:
                Debug.Log("어지러움");
                break;
            case POISONTYPE.BLIND:
                Debug.Log("실명");
                break;
            case POISONTYPE.VOMIT:
                Debug.Log("구토");
                break;
        }
    }
}
