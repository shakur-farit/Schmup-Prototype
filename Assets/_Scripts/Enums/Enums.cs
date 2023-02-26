/// <summary>
/// Enum to help with shooting modes of enemy
/// </summary>
public enum ShootModes { None, ShootAll };

/// <summary>
/// Enum to help with different movement modes of enemy
/// </summary>
public enum EnemyMovementModes { NoMovement, FollowTarget, Scroll };



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



/// <summary>
/// Enum to handle different drops from enemies.
/// </summary>
public enum DropsModes
{
    SmallHeal, LargeHeal, Shield, MachinegunWeapon, FireballWeapon, LazerWeapon,
    WeaponPowerLevelOne, WeaponPowerLevelTwo, WeaponPowerLevelThree
}



/// <summary>
/// Enum to handle different axis to check by position.
/// </summary>
public enum CheckByPositionModes { ByAxisX, ByAxisY }

