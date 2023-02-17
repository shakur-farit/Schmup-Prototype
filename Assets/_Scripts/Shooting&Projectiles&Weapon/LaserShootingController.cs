using UnityEngine;

public class LaserShootingController : ShootingController
{
    private LaserProjectile laserProj;
    private LaserShootDamageVFX laserEffects;
    private bool laserEnabled = false;
    private bool laserDamageVFXEnabled = false;
    private int damageAmount;
    private LayerMask enemyLayer;


    private void Start()
    {
        SetUpComponents();
    }


    /// <summary>
    /// Override ProcessInput() function of ShootingController.
    /// </summary>
    protected override void ProcessInput()
    {
        if (isPlayerControlled)
        {
            Fire();
        }
        else 
        { 
            if (!laserEnabled)
            {
                EnableLaser();
                laserEnabled = true;
            }

            UpdateLaser();
        }
            
    }

    /// <summary>
    /// Override Fire() function of ShootingController.
    /// Fire with laser if it possible.
    /// </summary>
    public override void Fire()
    {
        if (InputManager.instance.firePressed)
        {
            EnableLaser();
        }

        if (InputManager.instance.fireHeld)
        {
            UpdateLaser();
        }

        if (!InputManager.instance.fireHeld)
        {
            DisableLaser();
        }
    }

    /// <summary>
    /// Make laser visable.
    /// </summary>
    private void EnableLaser()
    {
        laserProj._lineRenderer.enabled = true;

        laserEffects.ShootVFXInstantiate(gameObject);

    }

    /// <summary>
    /// Update position of laser and its start/end points.
    /// </summary>
    private void UpdateLaser()
    {
        // Set start point of laser.
        laserProj._lineRenderer.SetPosition(0, (Vector2)laserProj.startPoint.position);

        // Set end ponit of laser.
        laserProj._lineRenderer.SetPosition(1, (Vector2)laserProj.endPoint.position);

        // Deduct direction form end point to hited object.
        Vector2 direction = (Vector2)laserProj.endPoint.position - (Vector2)transform.position;

        // Cut line renderer when it hit some object.
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction.normalized, direction.magnitude, enemyLayer);

        if (hit)
        {
            // Change end point of laser from endPoint to hited object's position.
            laserProj._lineRenderer.SetPosition(1, hit.point);

            if (hit.collider != null && hit.collider.GetComponent<Enemy>() != null)
            {
                Debug.Log(hit.collider.name);
                hit.collider.GetComponent<Health>().TakeDamage(damageAmount);

                if (!laserDamageVFXEnabled)
                {
                    laserEffects.DamageVFXInstantiate(gameObject);
                    laserDamageVFXEnabled = true;
                }

                laserEffects.DamageVFXPositionUpdate(laserProj._lineRenderer.GetPosition(1));
            }
        }
        else 
        { 
            laserEffects.DamageVFXDestroy();
            laserDamageVFXEnabled=false;
        }

        laserEffects.ShootVFXPositionUpdate();

    }

    /// <summary>
    /// Disactivated laser.
    /// </summary>
    private void DisableLaser()
    {
         Debug.Log("Dis");
        laserProj._lineRenderer.enabled = false;

        laserEffects.ShootVFXDestroy();

        laserEffects.DamageVFXDestroy();
        laserDamageVFXEnabled = false;
    }

    /// <summary>
    /// Set up components from this object.
    /// </summary>
    private void SetUpComponents()
    {
        laserProj = projectilePrefab.GetComponent<LaserProjectile>();
        laserEffects = projectilePrefab.GetComponent<LaserShootDamageVFX>();
        enemyLayer = 1 << LayerMask.NameToLayer("Enemy");
        damageAmount = GetComponentInChildren<Damage>().damageAmount;
    }
}