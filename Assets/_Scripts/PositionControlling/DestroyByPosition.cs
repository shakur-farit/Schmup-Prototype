using UnityEngine;

/// <summary>
/// This class destroy object by position
/// </summary>
public class DestroyByPosition : MonoBehaviour
{
    [Header("Component Setttings")]
    [Tooltip("Which axis will be cheked to destroy by position.")]
    public CheckByPositionModes checkByPositionMode;
    [Tooltip("Position to be checked to destroy.")]
    public Vector3 positionToDestroy = Vector3.zero;
    [Tooltip("Whether it be destroyed by player or not.")]
    public bool isDestructable = false;
    public Vector3 positionToBeDestructable = Vector3.zero;



    private void Update()
    {
        CheckToDestroy();
        CheckToBeDestructable();
    }

    /// <summary>
    /// Check and destroy object by position
    /// </summary>
    private void CheckToDestroy()
    {
        switch (checkByPositionMode)
        {
            case CheckByPositionModes.ByAxisX:
                if (transform.position.x < positionToDestroy.x)
                    Destroy(gameObject);
                break;

            case CheckByPositionModes.ByAxisY:
                if (transform.position.y < positionToDestroy.y)
                    Destroy(gameObject);
                break;
        }
    }

    /// <summary>
    /// Check and destroy object by position
    /// </summary>
    private void CheckToBeDestructable()
    {
        switch (checkByPositionMode)
        {
            case CheckByPositionModes.ByAxisX:
                if (transform.position.x < positionToBeDestructable.x)
                    isDestructable = true;
                break;

            case CheckByPositionModes.ByAxisY:
                if (transform.position.y < positionToBeDestructable.y)
                    isDestructable = true;
                break;
        }
    }
}
