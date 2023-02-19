using System.Collections;
using UnityEngine;

public class EffectDestroyer : MonoBehaviour
{
    public float timeToDestroy = 0;
    public bool hasTimeToDestroy = false;


    private void Update()
    {
        DestroyEffectObject();
    }

    public void DestroyEffectObject()
    {
        if (hasTimeToDestroy)
            StartCoroutine(DestroyObjectAfetrTime(gameObject, timeToDestroy));
        else
            StartCoroutine(DestroyObjectAfetrTime(gameObject, 0));
    }

   IEnumerator DestroyObjectAfetrTime(GameObject gameObject, float timeToDestroy)
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
