using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class manages uncloking levels.
/// </summary>
public class NextLevelUnlock : MonoBehaviour
{
    [Header("Components Setting")]
    [Tooltip("The value at index in this array show index of level which must be completed " +
    "to unlock Level Button in same index of \"levelButtons\".")]
    public int[] indexToUnlockNextLevel;
    [Tooltip("The button at index in this array will be unlocked when the level at index equal " +
        "to the value contained in array \"indexToUnlockNextLevel\" at index equal to index of THIS array, is completed.")]
    public GameObject[] levelButtons;
 
    private int completedLevel = 0;


    private void Start()
    {
        UnlockNextLevel();
        CheckArrays();
    }

    /// <summary>
    /// After completed level unlock next in Level Map.
    /// </summary>
    private void UnlockNextLevel()
    {
        // Looping levels opening in LevelMap if completed some level.
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (indexToUnlockNextLevel[i] <= PlayerPrefs.GetInt("Level"))
            {
                 Debug.Log("UnlockedLevel: " + (i + 1));
                 levelButtons[i].GetComponent<Button>().interactable = enabled;
            }
        }
    }

    /// <summary>
    /// Check the levelButtons and the indexToUnlockNextLevel arrays.
    /// </summary>
    private void CheckArrays()
    {
        if(levelButtons.Length != indexToUnlockNextLevel.Length)
        {
            Debug.LogWarning("The length of \"levelButtons\" and \"ndexToUnlockNextLevel\" arrays should be equal to the length.");
        }
        
        for(int i = 0; i < indexToUnlockNextLevel.Length; i++)
        {
            if (indexToUnlockNextLevel[i] < 0)
            {
                Debug.LogWarning("The value in \"indexToUnlockNextLevel\" should be not negative. Change value in " + i + " index.");
            }

            if(levelButtons == null)
            {
                Debug.LogWarning("The value in \"levelButtons\" can't be null.");
            }
        }
    }
}
