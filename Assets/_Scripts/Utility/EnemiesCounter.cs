using UnityEngine;

/// <summary>
/// This class count enemies.
/// </summary>
public class EnemiesCounter : MonoBehaviour
{
    [HideInInspector]
    public int amountOfEnemies = 0;

    /// <summary>
    /// Find all enemies in the scene.
    /// </summary>
    public void SetUpEnemies()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        amountOfEnemies = enemies.Length;

        if (amountOfEnemies < GetComponent<LevelWinable>().defeatForWin)
            Debug.LogWarning("Amount Of Enemies can't be lower than Defeat For Win");
    }
}
