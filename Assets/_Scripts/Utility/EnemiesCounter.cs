using UnityEngine;

/// <summary>
/// This class count enemies.
/// </summary>
public class EnemiesCounter : MonoBehaviour
{ 
    public int amountOfEnemies = 0;

    private void Start()
    {
       SetUpEnemies();
    }

    /// <summary>
    /// Find all enemies in the scene.
    /// </summary>
    private void SetUpEnemies()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        amountOfEnemies = enemies.Length;

        if (amountOfEnemies < GetComponent<LevelWinnable>().defeatForWin)
            Debug.LogWarning("Amount Of Enemies can't be lower than Defeat For Win");
    }
}
