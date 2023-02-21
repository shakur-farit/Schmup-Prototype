using UnityEngine;

/// <summary>
/// This class manage scores of the game.
/// </summary>
public class Score : MonoBehaviour
{
    [Header("Component Settings")]
    [Tooltip("How much score player have in current moment.")]
    public int currentScore = 0;
    [Tooltip("Highest score in this game.")]
    public int highScore = 0;


    private void Start()
    {
        LoadHighScore();
    }

    /// <summary>
    /// Change number of score.
    /// </summary>
    /// <param name="valueScore"></param>
    public void AddScore(int valueScore)
    {
        if (valueScore >= 0)
        {
            currentScore += valueScore;
            if (currentScore > highScore)
            {
                SaveHighestScore();
            }
        }
        else
            Debug.Log(" Value score of Enemy can't be negative.");
    }

    /// <summary>
    /// Load highest value of score.
    /// </summary>
    public void LoadHighScore()
    {
        if (PlayerPrefs.HasKey("High Score"))
        {
            highScore = PlayerPrefs.GetInt("High Score");
            Debug.Log("Load Highscoer");          
        }
    }

    /// <summary>
    /// Save highest value of score.
    /// </summary>
    private void SaveHighestScore()
    {
         highScore = currentScore;
         PlayerPrefs.SetInt("High Score", highScore);    
    }


}
