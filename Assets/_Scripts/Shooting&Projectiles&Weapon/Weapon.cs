using UnityEngine;

/// <summary>
/// This class to control weapon.
/// </summary>
public class Weapon : MonoBehaviour
{
    [Header("Weapon's Settings")]
    [Tooltip("Index of weapon.")]
    public int weaponIndex;
    [Tooltip("Weapon's power levels.")]
    public WeaponPowerLevel[] weaponPowerLevels;
    //[HideInInspector]
    public int currentPowerLevel = 1;

    /// <summary>
    /// Switch power levels of weapon.
    /// </summary>
    /// <param name="indexOfDropedPowerLevel"></param>
    public void LevelPowerSwicth(int indexOfDropedPowerLevel)
    {
        // If droped index not more than number of weapon power levels...
        if (indexOfDropedPowerLevel <= weaponPowerLevels.Length)
        {
            // If droped index more than current power level...
            if (indexOfDropedPowerLevel >= currentPowerLevel)
            {
                // Find power level equal droped level index.
                foreach (WeaponPowerLevel weaponPowerLevel in weaponPowerLevels)
                {
                    if (weaponPowerLevel.powerLevelIndex == indexOfDropedPowerLevel)
                    {
                        // Active it.
                        weaponPowerLevel.gameObject.SetActive(true);
                    }
                    else
                    {
                        // Deactive another levels.
                        weaponPowerLevel.gameObject.SetActive(false);
                    }
                }
                currentPowerLevel = indexOfDropedPowerLevel;
            }
        }
        else // If droped index more than number of weapon power levels...
        {
            // Activete last power level.
            weaponPowerLevels[weaponPowerLevels.Length -1].gameObject.SetActive(true);
            currentPowerLevel = indexOfDropedPowerLevel;
        }

        
    }
}
