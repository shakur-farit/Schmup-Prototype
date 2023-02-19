using UnityEngine;

/// <summary>
/// This class make switching of weapon.
/// </summary>
public class WeaponSwitcher : MonoBehaviour
{
    [Header("Weapon's Settings")]
    [Tooltip("Array of weapons.")]
    public Weapon[] weapons;

    [HideInInspector]
    public int currentWeaponIndex = 1;

    /// <summary>
    /// Switch wepons.
    /// </summary>
    /// <param name="indexOfDropedWeapon"></param>
    public void WeaponsSwitch(int indexOfDropedWeapon)
    {
        if( indexOfDropedWeapon != currentWeaponIndex)
        {
            // Get index of power level of current weapon.
            int indexOfCurrentWeaponPowerLevel = GetComponentInChildren<Weapon>().currentPowerLevel;

            foreach (Weapon weapon in weapons)
            {
                if (weapon != null)
                {
                    if (weapon.weaponIndex == indexOfDropedWeapon)
                    {
                        weapon.gameObject.SetActive(true);

                        // if power level of current wepon more than 1, save current power level for droped weapon.
                        weapon.LevelPowerSwicth(indexOfCurrentWeaponPowerLevel);
                    }
                    else
                    {
                        weapon.gameObject.SetActive(false);
                    }
                } 
                else
                {
                    Debug.Log("You need atach Weapon type game object with " + indexOfDropedWeapon + " index to WeaponSwitcher type game object.");
                }           
            }
            currentWeaponIndex = indexOfDropedWeapon;
        }
    }
}
