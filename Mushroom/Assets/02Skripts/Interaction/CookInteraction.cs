using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookInteraction : Interaction
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
        int repeat = 6;
        float moveAmount = 0.1f;
        float moveDuration = 2f;
        for(int i = 0; i < repeat; i++)
        {
            yield return MoveUpDown(go, Vector3.up* moveAmount, moveDuration);
            yield return MoveUpDown(go, Vector3.down* moveAmount, moveDuration);
        }

        go.AddComponent<Rigidbody>();
        Vector3 jumpDir = Vector3.up * 3f;
        go.GetComponent<Rigidbody>().AddForce(jumpDir, ForceMode.Impulse);
        Renderer renderer = go.GetComponent<Renderer>();
        renderer.material.color = Color.blue;
        isInteracting =false;
        go.GetComponent<MushroomBase>().canPick = true;
        go.GetComponent<MushroomBase>().cooked = true;
        go.gameObject.tag = "Selectable";
    }

    private IEnumerator MoveUpDown(GameObject go, Vector3 dir, float dur)
    {
        float time = 0;
        while (time < 2f)
        {
            go.transform.position += dir * (Time.deltaTime / dur);

            time += Time.deltaTime;
            yield return null;
        }
    }
}
