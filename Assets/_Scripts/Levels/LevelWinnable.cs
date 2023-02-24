using UnityEngine;

/// <summary>
/// Manage of level winning.
/// </summary>
public class LevelWinnable : MonoBehaviour
{
    [Header("Component Settings")]
    [Tooltip("Whether this level winnable or not.")]
    public bool isLevelWinable = true;
    [Tooltip("How many enemies must be defeated to win level.")]
    public int defeatForWin = 0;
    [Tooltip("How many enemies defeated in current moment.")]
    public int defeatedEnemies = 0;


    private void OnEnable()
    {
        GameEvents.OnLevelCompliete += WinLevel;
    }
    private void OnDisable()
    {
        GameEvents.OnLevelCompliete -= WinLevel;
    }


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
    private void WinLevel()
    {
        GetComponent<GameEvents>().ShowPopupPanel("Win");
        Time.timeScale = 0;       
    }
}
