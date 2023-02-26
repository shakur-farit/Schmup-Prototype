using UnityEngine;

/// <summary>
/// Manage of level winning.
/// </summary>
public class LevelWinnable : MonoBehaviour
{
    [Header("Component Settings")]
    [Tooltip("Whether this level winnable with defeated enemies or not.")]
    public bool isLevelWinnableWithEnemiyDefeat = false;
    [Tooltip("How many enemies must be defeated to win level.")]
    public int defeatForWin = 0;
    [Tooltip("How many enemies defeated in current moment.")]
    public int defeatedEnemies = 0;
    [Tooltip("Whether this level winnable with defeated boss or not.")]
    public bool isLevelWinnableWithBossDefeat = false;
    [Tooltip("Game object of the boss.")]
    public GameObject boss;
    [Tooltip("Whether this level winnable with accrosing the finish line or not.")]
    public bool isLevelWinnableWithAccrosFinishLine = true;

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
