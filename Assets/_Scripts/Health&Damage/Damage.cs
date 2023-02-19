using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the dealing of damage to health components.
/// </summary>
public class Damage : MonoBehaviour
{
    [Header("Team Settings")]
    [Tooltip("The team associated with this damage.")]
    public int teamId = 0;
    [Header("Damage Settings")]
    [Tooltip("How much damage to deal.")]
    public int damageAmount = 1;
    [Tooltip("Whether or not to destroy the attached game object after dealing damage.")]
    public bool destroyAfterDamage = true;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        DealDamage(collision.gameObject);
    }


    /// <summary>
    /// Description:
    /// This function deals damage to a health component if the collided 
    /// with gameobject has a health component attached AND it is on a different team.
    /// If object have shield, deals damage to shield component firstly.
    /// Inputs:
    /// GameObject collisionGameObject
    /// Returns:
    /// void (no return)
    /// </summary>
    /// <param name="collisionGameObject">The game object that has been collided with</param>
    private void DealDamage(GameObject collisionGameObject)
    {
        // Find Health component on collided game object.
        Health collidedHealth = collisionGameObject.GetComponent<Health>();
        // Find Shield component on collided game object.
        Shield shield = collisionGameObject.GetComponent<Shield>();


        if (collidedHealth != null)
        {
            if (collidedHealth.teamId != this.teamId)
            {
                // if this object have shield
                if (shield != null && shield.hasShield)
                {
                    // Deal damage to the shield.
                    shield.TakeDamage(damageAmount);
                }
                else
                {
                    // Deal damage to the object.
                    collidedHealth.TakeDamage(damageAmount);
                }

                if (gameObject.GetComponent<ShootDamageVFX>() != null)
                {
                    ShootDamageVFX effect = gameObject.GetComponent<ShootDamageVFX>();
                    effect.DamageVFXInstantiate(gameObject);
                }

                if (destroyAfterDamage)
                {
                    // if this game object have Enemy component.
                    if (gameObject.GetComponent<Enemy>() != null)
                    {
                        // call DoBeforeDestroy function from Enemy componnet on this object.
                        gameObject.GetComponent<Enemy>().DoBeforeDestroy();
                        // call SpawnDrop function from DropSpawner componnet on this object.
                        gameObject.GetComponent<DropSpawner>().SpawnDrop();
                    }
                    Destroy(this.gameObject);                    
                }
            }
        }
    }
}
