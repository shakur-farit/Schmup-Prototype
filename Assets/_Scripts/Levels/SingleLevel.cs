using UnityEngine;

/// <summary>
/// This class manages level's index
/// </summary>
public class SingleLevel : MonoBehaviour
{
    [Header("Component Settings")]
    [Tooltip("Index of current level.")]
    [SerializeField] private int levelIndex;

    private void OnEnable()
    {
        GameEvents.OnLevelCompliete += SaveCompletedLevelIndex;
    }

    private void OnDisable()
    {
        GameEvents.OnLevelCompliete -= SaveCompletedLevelIndex;
    }

    /// <summary>
    /// Save highest index of completed level in PlayerPrefs
    /// </summary>
    private void SaveCompletedLevelIndex()
    {
        Debug.Log("Saved Completed Level");
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Level", levelIndex);
        }
    }
}
