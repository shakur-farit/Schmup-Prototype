
// Enums of enemy.

/// <summary>
/// Enum to help with shooting modes of enemy
/// </summary>
public enum ShootMode { None, ShootAll };

/// <summary>
/// Enum to help with different movement modes of enemy
/// </summary>
public enum EnemyMovementModes { NoMovement, FollowTarget, Scroll };


// Enums of player.

/// <summary>
/// Enum which stores different aiming modes of player
/// </summary>
public enum AimModes { AimTowardsMouse, AimForwards };

/// <summary>
/// Enum to handle different movement modes for the player
/// </summary>
public enum MovementModes { MoveHorizontally, MoveVertically, MoveToward, FreeRoam, Astroids };

/// <summary>
/// Enum to handle different toward movement modes for the player
/// </summary>
public enum TowardMovementModes { HorizontallyMove, VerticallyMove }


// Enums of drops.

/// <summary>
/// Enum to handle different drops from enemies.
/// </summary>
public enum DropsMode
{
    SmallHeal, LargeHeal, Shield, MachinegunWeapon, FireballWeapon, LazerWeapon,
    WeaponPowerLevelOne, WeaponPowerLevelTwo, WeaponPowerLevelThree
}

