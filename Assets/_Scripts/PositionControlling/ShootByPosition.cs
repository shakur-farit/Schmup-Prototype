using UnityEngine;

public class ShootByPosition : MonoBehaviour
{
    [Header("Component Settings")]
    [Tooltip("Whether this shooting controller can shoot or not")]
    public bool canShoot = false;
    [Tooltip("Which axis will be cheked to shoot by position")]
    public CheckByPositionModes checkByPositionMode;
    [Tooltip("Position to be checked to shoot")]
    public Vector3 positionToShoot = Vector3.zero;

    private void Update()
    {
        CheckToShoot();
    }

    private void CheckToShoot()
    {
        switch (checkByPositionMode)
        {
            case CheckByPositionModes.ByAxisX:
                if (transform.position.x < positionToShoot.x)
                    canShoot = true;
                break;

            case CheckByPositionModes.ByAxisY:
                if (transform.position.y < positionToShoot.y)
                    canShoot = true;
                break;
        }
    }
}
