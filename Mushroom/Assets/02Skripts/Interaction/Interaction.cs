using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    public bool isInteracting;
    public Transform cookPos;
    public abstract void Interact(GameObject gameObject);
}
