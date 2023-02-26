using UnityEngine;

/// <summary>
/// This class controll movement of Game Container
/// </summary>
public class GameContainerMoveController : MonoBehaviour
{
    [Header("Component Setting")]
    [Tooltip("Direction of movement.")]
    [SerializeField] private Vector3 derection = Vector3.zero;
    [Tooltip("Movement speed")]
    [SerializeField] private float moveSpeed = 0f;


    private void Update()
    {
        Move();
    }

    /// <summary>
    /// Make move.
    /// </summary>
    private void Move()
    {
        Vector3 pos = derection * moveSpeed * Time.deltaTime;
        transform.position += pos;
    }
}
