using UnityEngine;

/// <summary>
/// Manage of level winning.
/// </summary>
public class LevelWinable : MonoBehaviour
{
    [Header("Component Settings")]
    [Tooltip("Whether this level winnable or not.")]
    public bool isLevelWinable = true;
    [Tooltip("How many enemies must be defeated to win level.")]
    public int defeatForWin = 0;
    [Tooltip("How many enemies defeated in current moment.")]
    public int defeatedEnemies = 0;


    /// <summary>
    /// Increment defeatedEnemies
    /// </summary>
    public void IncrementDefeatedEnemies()
    {
        defeatedEnemies++;
    }

    /// <summary>
    /// Show popup pnale of win and freez scene.
    /// </summary>
    /// <param name="nameOfPopupPanel"></param>
    public void WinLevel(string nameOfPopupPanel)
    {      
        GetComponent<GameEvents>().ShowPopupPanel(nameOfPopupPanel);
        Time.timeScale = 0;       
    }
}
