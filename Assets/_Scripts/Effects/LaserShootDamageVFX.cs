using UnityEngine;

public class LaserShootDamageVFX : ShootDamageVFX
{
    LaserProjectile laser;

    private void Start()
    {
        laser = GetComponent<LaserProjectile>();
    }


    /// <summary>
    /// Update position of laser's shoot VFX.
    /// </summary>
    public void ShootVFXPositionUpdate()
    {

        // If start effect not null make it position equal position of start point of laser.
        if (shootVFX != null)
            shootVFXCont.transform.position = (Vector2)laser.startPoint.position;

    }

    /// <summary>
    /// Update position of laser's damage VFX.
    /// </summary>
    public void DamageVFXPositionUpdate(Vector2 damagePointPos)
    {
        // If end effect not null make it position equal position of end point of laser.
        if (damageVFX != null)
            damageVFXCont.transform.position = damagePointPos;
    }

    /// <summary>
    /// Destroy shoot effect of laser.
    /// </summary>
    public void ShootVFXDestroy()
    {
        Destroy(shootVFXCont);
    }

    /// <summary>
    /// Destroy damage effect of laser.
    /// </summary>
    public void DamageVFXDestroy()
    {
        Destroy(damageVFXCont);
    }
}
