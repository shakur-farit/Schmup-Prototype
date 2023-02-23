using UnityEngine;

/// <summary>
/// Class of events in the game.
/// </summary>
public class GameEvents : MonoBehaviour
{
    //Buttons events.
    public delegate void buttonsAction();  
    public static event buttonsAction OnQuitButton;
    public static event buttonsAction OnPauseButton;
    public static event buttonsAction OnResumeButton;
    public static event buttonsAction OnRestartButton;

    public delegate void loadByNameAction(string name);
    public static event loadByNameAction OnLoadLevel;
    public static event loadByNameAction OnShowPopupPanel;
    public static event loadByNameAction OnBackButton;



    public void ShowPopupPanel(string popupPanelName)
    {
        if (OnShowPopupPanel != null)
            OnShowPopupPanel(popupPanelName);
    }

    public void ClosePopupPanel(string popupPanelName)
    {
        if (OnBackButton != null)
            OnBackButton(popupPanelName);
    }

    public void LoadLevel(string levelToLoadName)
    {
        if (OnLoadLevel != null)
            OnLoadLevel(levelToLoadName);
    }

    public void RestartLevel()
    {
        if (OnRestartButton != null)
            OnRestartButton();
    }

    public void PauseGame()
    {
        if (OnPauseButton != null)
            OnPauseButton();
    }

    public void UnpauseGame()
    {
        if (OnResumeButton != null)
            OnResumeButton();
    }

    public void QuitGame()
    {
        if (OnQuitButton != null)
            OnQuitButton();
    }
}
