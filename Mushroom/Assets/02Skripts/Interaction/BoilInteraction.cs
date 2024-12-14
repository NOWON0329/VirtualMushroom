using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilInteraction : Interaction
{
    public override void Interact(GameObject go)
    {
        if (isInteracting)
            return;
        if (go.GetComponent<MushroomBase>().cooked)
            return;

        StartCoroutine(InteractCoolTime(go));
    }

    private IEnumerator InteractCoolTime(GameObject go)
    {
        go.gameObject.tag = "Untagged";
        go.GetComponent<MushroomBase>().canPick = false;
        isInteracting = true;
        float time = 0;
        while (time < 5f)
        {
            int dir = (int)time / 2 == 0 ? 1 : -1;
            go.transform.position += new Vector3(0, dir * 0.0001f, 0);

            time += Time.deltaTime;
            yield return null;
        }

        go.AddComponent<Rigidbody>();
        Vector3 jumpDir = Vector3.up * 3f;
        go.GetComponent<Rigidbody>().AddForce(jumpDir, ForceMode.Impulse);
        Renderer renderer = go.GetComponent<Renderer>();
        renderer.material.color = go.GetComponent<MushroomBase>().CookMushroom(COOKTYPE.BOIL) ? Color.blue : Color.green;
        isInteracting =false;
        go.GetComponent<MushroomBase>().canPick = true;
        go.GetComponent<MushroomBase>().cooked = true;
        go.gameObject.tag = "Selectable";
    }
}
