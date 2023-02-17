using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the health state of a game object.
/// 
/// Implementation Notes: 2D Rigidbodies must be set to never sleep for this to interact with trigger stay damage.
/// </summary>
public class Health : MonoBehaviour, ITakeDamage
{
    [Header("Team Settings")]
    [Tooltip("The team associated with this damage")]
    public int teamId = 0;

    [Header("Health Components")]
    [Tooltip("How many health have in current time.")]
    [SerializeField] private int currentHealth = 3;
    [Tooltip("The maximum number of health which is possible.")]
    [SerializeField] private int maximumHealth = 5;

    [Header("Effects & Polish")]
    [Tooltip("The effect to create when this health dies")]
    public GameObject deathEffect;
    [Tooltip("The effect to create when this health is damaged")]
    public GameObject hitEffect;


    public int CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }




    /// <summary>
    /// Description:
    /// Standard Unity function called once per frame
    /// Inputs:
    /// none
    /// Returns:
    /// void (no return)
    /// </summary>
    void Update()
    {
        HealthIndicator();
    }



    /// <summary>
    /// Description:
    /// Applies damage to the health unless the health is invincible.
    /// Inputs:
    /// int damageAmount
    /// Returns:
    /// void (no return)
    /// </summary>
    /// <param name="damageAmount">The amount of damage to take</param>
    public void TakeDamage(int damageAmount)
    {
        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, transform.rotation, null);
        }

        currentHealth -= damageAmount;

        CheckDeath();
    }

    /// <summary>
    /// Description:
    /// Applies healing to the health, capped out at the maximum health.
    /// Inputs:
    /// int healingAmount
    /// Returns:
    /// void (no return)
    /// </summary>
    /// <param name="healingAmount">How much healing to apply</param>
    public void ReceiveHealing(int healingAmount)
    {
        currentHealth += healingAmount;
        HealthIndicator();
        CheckDeath();
    }

    /// <summary>
    /// Description:
    /// Checks if the health is dead or not. If it is, true is returned, false otherwise.
    /// Calls Die() if the health is dead.
    /// Inputs:
    /// none
    /// Returns:
    /// bool
    /// </summary>
    /// <returns>Bool: true or false value representing if the health has died or not (true for dead)</returns>
    private bool CheckDeath()
    {
        if (currentHealth <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Description:
    /// Handles the death of the health. If a death effect is set, it is created. If lives are being used, the health is respawned.
    /// If lives are not being used or the lives are 0 then the health's game object is destroyed.
    /// Inputs:
    /// none
    /// Returns:
    /// void (no return)
    /// </summary>
    public void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation, null);
        }
        HandleDeath(); 
    }

    /// <summary>
    /// Description:
    /// Handles death.
    /// Inputs:
    /// none
    /// Returns:
    /// void (no return)
    /// </summary>
    private void HandleDeath()
    {
        if (gameObject.tag == "Player" && GameManager.instance != null)
        {
            GameManager.instance.GameOver();
        }
        if (gameObject.GetComponent<Enemy>() != null)
        {
            gameObject.GetComponent<Enemy>().DoBeforeDestroy();

            if (gameObject.GetComponent<DropSpawner>() != null)
            {
                gameObject.GetComponent<DropSpawner>().SpawnDrop();
            }
        }
        Destroy(this.gameObject);
    }

    private void HealthIndicator()
    {
        if (currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }

        //for (int i = 0; i < lives.Length; i++)
        //{
        //    if (i < Mathf.RoundToInt(currentLives))
        //    {
        //        lives[i].sprite = fullLive;
        //    }
        //    else
        //    {
        //        lives[i].sprite = emptyLive;
        //    }
        //}
    }
}
