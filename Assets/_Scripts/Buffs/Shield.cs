using UnityEngine;

/// <summary>
/// This class responsible for Shield buff and its performance.
/// </summary>
public class Shield : MonoBehaviour, ITakeDamage
{
    [Header("Shield Component")]
    [Tooltip("Whether the object shield or not")]
    public bool hasShield = false;
    [Tooltip("Strength of sheild")]
    public int currentStrength = 3;
    [Tooltip("Maximum strength of sheild")]
    public int maximumSstrength = 3;


    private Transform shield;


    private void Start()
    {
        SetUpShield();
    }

    /// <summary>
    /// Deal damage to shield.
    /// </summary>
    /// <param name="damageAmount"></param>
    public void TakeDamage(int damageAmount)
    {
        currentStrength -= damageAmount;
        CheckShildStrength();
    }

    /// <summary>
    /// Check currentStrengrth <= 0 or not.
    /// </summary>
    private void CheckShildStrength()
    {
        if (currentStrength <= 0)
        {
            DestroyShield();
        }
    }

    /// <summary>
    /// Destroyed sheild.
    /// </summary>
    private void DestroyShield()
    {
        shield.gameObject.SetActive(false);
        hasShield = false;   
    }

    /// <summary>
    /// Find game object with Shield name.
    /// </summary>
    private void SetUpShield()
    {
        shield = transform.Find("Shield");

        if ( shield != null && !hasShield)
        {
            shield.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Activate shield (when player take drop with shield).
    /// </summary>
    public void ActivateShield()
    {
        shield.gameObject.SetActive(true);
        ReloadShield();
        hasShield = true;
    }

    /// <summary>
    /// Change currentStrength value to maximimStrength.
    /// </summary>
    public void ReloadShield()
    {
        currentStrength = maximumSstrength;
        HealthIndicator();
    }

    private void HealthIndicator()
    {
        if (currentStrength > maximumSstrength)
        {
            currentStrength = maximumSstrength;
        }
    }
}
