using System.Collections;
using UnityEngine;

/// <summary>
/// Class which instantiate and controll shoot and damage effects of projectiles.
/// </summary>
public class ShootDamageVFX : MonoBehaviour
{
    [Header("Component Settings")]
    [Tooltip("Visual effect shooting.")]
    public GameObject shootVFX;
    [Tooltip("Visual effect for damage.")]
    public GameObject damageVFX;
    [Tooltip("The transform in the heirarchy which holds VFX if any")]
    public GameObject _VFXHolder = null;

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

            FindVFXHolder();

            if (_VFXHolder != null)
                shootVFXCont.gameObject.transform.SetParent(_VFXHolder.transform);
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

            FindVFXHolder();

            if (_VFXHolder != null)
                damageVFXCont.gameObject.transform.SetParent(_VFXHolder.transform);
        }
    }

    /// <summary>
    /// Description:
    /// Attempts to find VFXHolder in hierarchy to hold VFXeffect's game objects.
    /// Inputs:
    /// none
    /// Returns:
    /// void (no return)
    /// </summary>
    private void FindVFXHolder()
    {
        if(_VFXHolder == null)
            _VFXHolder = GameObject.Find("VFXHolder");

        if (_VFXHolder == null)
             Debug.Log("Create the Empty Object with \"VFXHolder\" name to hold VFX objects in it. ");
    }
}
