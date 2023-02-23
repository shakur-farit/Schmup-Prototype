using UnityEngine;

/// <summary>
/// Class which manages the UI in game.
/// </summary>
public class UIManager : MonoBehaviour
{
    private UIPopup[] uiPopupPanels;

    private void OnEnable()
    {
        GameEvents.OnBackButton += ClosePopupPanel;
        GameEvents.OnShowPopupPanel += ShowPopupPanel;
    }

    private void OnDisable()
    {
        GameEvents.OnBackButton -= ClosePopupPanel;
        GameEvents.OnShowPopupPanel -= ShowPopupPanel;
    }


    private void Awake()
    {
        uiPopupPanels = FindObjectsOfType<UIPopup>();
    }

    /// <summary>
    /// Description:
    /// Enable popup panel.
    /// Input:
    /// string nameOfPopup
    /// Returns:
    /// void (no return)
    /// </summary>
    /// <param name="nameOfPopup"> Name of opening popup panel.</param>
    private void ShowPopupPanel(string nameOfPopup)
    {
        for (int i = 0; i < uiPopupPanels.Length; i++)
        {
            if (uiPopupPanels[i].popupPanelName == nameOfPopup)
            {
                uiPopupPanels[i].gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Description:
    /// Disable popup panel.
    /// Input:
    /// string nameOfPopup
    /// Returns:
    /// void (no return)
    /// </summary>
    /// <param name="nameOfPopup"> Name of opening popup panel.</param>
    private void ClosePopupPanel(string nameOfPopup)
    {
        for (int i = 0; i < uiPopupPanels.Length; i++)
        {
            if (uiPopupPanels[i].popupPanelName == nameOfPopup)
            {
                uiPopupPanels[i].PlayPopupDisappearAnimation();
            }
        }
    }
}
