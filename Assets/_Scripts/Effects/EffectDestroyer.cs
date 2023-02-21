using System.Collections;
using UnityEngine;

/// <summary>
/// This class manage to destroying of VFX.
/// </summary>
public class EffectDestroyer : MonoBehaviour
{
    [Header("Component Settings")]
    [Tooltip("Whether destroy time or not.")]
    public bool hasTimeToDestroy = false;
    [Tooltip("After how many seconds VFX will be destroy")]
    public float timeToDestroy = 0;
 

    private void Update()
    {
        DestroyVFXObject();
    }


    /// <summary>
    /// Destroy the VFX.
    /// </summary>
    public void DestroyVFXObject()
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
