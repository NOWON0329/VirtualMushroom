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
    public POISONTYPE poisonType;
    public COOKTYPE cookType;

    public virtual void EatMushroom() { }
    public virtual void CookMushroom() { }
}
