using UnityEngine;

/// <summary>
/// A class which controls drop behaviour
/// </summary>
public class Drop : MonoBehaviour
{
    [Header("Drop's Components.")]
    [Tooltip("Which kind of drop on this.")]
    public DropsModes dropMode = DropsModes.Shield;
    [Tooltip("Number of receive healing from Small Heal drop.")]
    [SerializeField] private int smallHeal;
    [Tooltip("Number of receive healing from Large Heal drop.")]
    [SerializeField] private int largeHeal;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Shield shield = collision.gameObject.GetComponent<Shield>();
        Health health = collision.gameObject.GetComponent<Health>();
        WeaponSwitcher weaponSwitcher = collision.gameObject.GetComponentInChildren<WeaponSwitcher>();
        Weapon weaponPower = collision.gameObject.GetComponentInChildren<Weapon>();

        if(collision.gameObject.tag == "Player")
        {
            if (shield != null)
            {
                // If droped shield.
                switch (dropMode)
                {
                    case DropsModes.Shield:
                        if(!shield.hasShield)
                            // activate it.
                            shield.ActivateShield();
                        else
                            // if shield acteve, reload (recieve health of shield).
                            shield.ReloadShield();
                        break;
                }
            }
            if(health != null)
            {
                // If droped health.
                switch (dropMode)
                {
                    case DropsModes.SmallHeal:
                        health.ReceiveHealing(smallHeal);
                        break;
                    case DropsModes.LargeHeal:
                        health.ReceiveHealing(largeHeal);
                        break;
                }
            }
            if(weaponSwitcher != null)
            {
                // Index of droped weapon.
                int indexOfDropedWeapon;

                // If droped weapon.
                switch (dropMode)
                {
                    case DropsModes.MachinegunWeapon:
                        indexOfDropedWeapon = 1;
                        weaponSwitcher.WeaponsSwitch(indexOfDropedWeapon);
                        break;
                    case DropsModes.FireballWeapon:
                        indexOfDropedWeapon = 2;
                        weaponSwitcher.WeaponsSwitch(indexOfDropedWeapon);
                        break;
                    case DropsModes.LazerWeapon:
                        indexOfDropedWeapon = 3;
                        weaponSwitcher.WeaponsSwitch(indexOfDropedWeapon);
                        break;
                }
            }
            if(weaponPower != null)
            {
                // Index of droped Power Level.
                int indexOfPowerLevel;

                switch (dropMode)
                {
                    case DropsModes.WeaponPowerLevelOne:
                        indexOfPowerLevel = 1;
                        weaponPower.LevelPowerSwicth(indexOfPowerLevel);
                        break;
                    case DropsModes.WeaponPowerLevelTwo:
                        indexOfPowerLevel = 2;
                        weaponPower.LevelPowerSwicth(indexOfPowerLevel);
                        break;
                    case DropsModes.WeaponPowerLevelThree:
                        indexOfPowerLevel = 3;
                        weaponPower.LevelPowerSwicth(indexOfPowerLevel);
                        break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
