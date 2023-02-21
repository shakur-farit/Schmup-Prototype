using UnityEngine;

/// <summary>
/// Class which instantiate and controll shoot and damage VFX of laser.
/// </summary>
public class LaserShootDamageVFX : ShootDamageVFX
{
    LaserProjectile laser;

    private void Start()
    {
        laser = GetComponent<LaserProjectile>();
    }


    public override void ShootVFXInstantiate(GameObject posForInst)
    {
        base.ShootVFXInstantiate(posForInst);

        if (shootVFX != null)
            shootVFXCont.gameObject.transform.SetParent(this.transform);
    }

    public override void DamageVFXInstantiate(GameObject posForInst)
    {
        base.DamageVFXInstantiate(posForInst);

        if (damageVFX != null)
            damageVFXCont.gameObject.transform.SetParent(this.transform);
    }

    /// <summary>
    /// Update position of laser's shoot VFX.
    /// </summary>
    public void ShootVFXPositionUpdate(Vector2 shootPointPos, Quaternion rotation)
    {

        // If start effect not null make it position equal position of start point of laser.
        if (shootVFX != null)
        {
            shootVFXCont.transform.position = shootPointPos;
            shootVFXCont.transform.rotation = rotation;
        }

    }

    /// <summary>
    /// Update position of laser's damage VFX.
    /// </summary>
    public void DamageVFXPositionUpdate(Vector2 damagePointPos, Quaternion rotation)
    {
        // If end effect not null make it position equal position of end point of laser.
        if (damageVFX != null)
        {
            damageVFXCont.transform.position = damagePointPos;
            damageVFXCont.transform.rotation = rotation;
        }
    }

    /// <summary>
    /// Destroy shoot VFX of laser.
    /// </summary>
    public void ShootVFXDestroy()
    {
        Destroy(shootVFXCont);
    }

    /// <summary>
    /// Destroy damage VFX of laser.
    /// </summary>
    public void DamageVFXDestroy()
    {
        Destroy(damageVFXCont);
    }
}
