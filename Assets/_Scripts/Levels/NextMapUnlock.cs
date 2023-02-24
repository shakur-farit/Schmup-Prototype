using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class manages maps unlocking.
/// </summary>
public class NextMapUnlock : MonoBehaviour
{
    [Header("Components Setting")]
    [Tooltip("The value at index in this array show index of level which must be completed " +
    "to unlock Level Map Button in same index of \"mapButtons\".")]
    public int[] lastLevelIndexInMap;
    [Tooltip("The button at index in this array will be unlocked when the level at index equal " +
        "to the value contained in array \"lastLevelIndexInMap\" at index equal to index of THIS array, is completed.")]
    public GameObject[] mapButtons;
  

    private void Start()
    {
        UnlockNextMap();
        CheckLastLevelIndex();
    }

    /// <summary>
    /// Unlock next map in the game.
    /// </summary>
    private void UnlockNextMap()
    {
        for (int i = 0; i < mapButtons.Length; i++)
        {
            // If completed level's index equal or more than index of last level in current map unlock next. 
            if (lastLevelIndexInMap[i] <= PlayerPrefs.GetInt("Level"))
            {
                mapButtons[i].GetComponent<Button>().interactable = enabled;
                Debug.Log("Unlock" + " map " + (i + 1));
            }
        }
    }

    /// <summary>
    /// Check value in lastLevelIndexInMap.
    /// </summary>
    private void CheckLastLevelIndex()
    {
        if (mapButtons.Length != lastLevelIndexInMap.Length)
        {
            Debug.LogWarning("The length of \"mapButtons\" and \"lastLevelIndexInMap\" arrays should be equal to the length.");
        }

        for (int i = 0; i < lastLevelIndexInMap.Length; i++)
        {
            if (lastLevelIndexInMap[i] < 0)
            {
                Debug.LogWarning("The value in \"lastLevelIndexInMap\" can't be negative. Change value in index " + i);
            }

            if (mapButtons == null)
            {
                Debug.LogWarning("The value in \"mapButtons\" can't be null.");
            }
        }
    }
}
