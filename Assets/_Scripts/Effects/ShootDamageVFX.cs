using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDamageVFX : MonoBehaviour
{
    [Header("Component Settings")]
    [Tooltip("Visual effect shooting.")]
    public GameObject shootVFX;
    [Tooltip("Visual effect for damage.")]
    public GameObject damageVFX;

    // Containers for shoot/damage VFX.
    protected GameObject shootVFXCont;
    protected GameObject damageVFXCont;




    /// <summary>
    /// Instatiat shoot effect of projectile.
    /// </summary>
    public virtual void ShootVFXInstantiate( GameObject posForInst)
    {
        if (shootVFX != null)
        {
            shootVFXCont = Instantiate(shootVFX, posForInst.transform.position, posForInst.transform.rotation);
        }
    }

    /// <summary>
    /// Instatiat damage effect of projectile.
    /// </summary>
    public virtual void DamageVFXInstantiate(GameObject posForInst)
    {
        if (damageVFX != null)
        {
            damageVFXCont = Instantiate(damageVFX, posForInst.transform.position, posForInst.transform.rotation);
        }
    }
}
