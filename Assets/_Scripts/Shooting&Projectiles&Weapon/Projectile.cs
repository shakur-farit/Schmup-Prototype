using UnityEngine;

/// <summary>
/// A class to make projectiles move
/// </summary>
public class Projectile : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("The distance this projectile will move each second.")]
    public float projectileSpeed = 3.0f;

    [Header("Destructible Settings")]
    [Tooltip("Whether projectiles is destroctible")]
    public bool isDestructible = false;
    [Tooltip("Time to destruction")]
    public float timeToDestruct = 5f;

    private float startTime = 0f;

    

    /// <summary>
    /// Description:
    /// Standard Unity function called once per frame
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
    private void Update()
    {
        MoveProjectile();
        DestroyProjectile();
    }

    /// <summary>
    /// Description:
    /// Move the projectile in the direction it is heading
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
    private void MoveProjectile()
    {
        // move the transform
        transform.position = transform.position + transform.up * projectileSpeed * Time.deltaTime;
    }

    /// <summary>
    /// Destroy projectile after timeToDestruct seconds.
    /// </summary>
    private void DestroyProjectile()
    {
        startTime += 1f * Time.deltaTime;
        // Destroy projectile if there was no collision
        if (isDestructible && startTime >= timeToDestruct)
        {
            Destroy(gameObject);
        }
    }
 }

