using UnityEngine;

public class LaserProjectile : Projectile { 

    [Header("Component Settings")]
    [Tooltip("Point of laser starting.")]
    public Transform startPoint;
    [Tooltip("Point of laser ending.")]
    public Transform endPoint;
    [Tooltip("Game object with Line Renderer component.")]
    public LineRenderer _lineRenderer;

}
