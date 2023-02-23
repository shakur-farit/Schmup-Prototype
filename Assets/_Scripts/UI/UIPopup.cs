using UnityEngine;

/// <summary>
/// This class mark popup panel and close it.
/// </summary>
public class UIPopup : MonoBehaviour
{
    [Tooltip("Index of the Popup Panel.")]
    public string popupPanelName;

    public Animator animator;


    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        // Disable popup panel on application starting.
        gameObject.SetActive(false);
    }


    /// <summary>
    /// Trigger "hide" parameter to play Popup_Disappear animation clip. 
    /// </summary>
    public void PlayPopupDisappearAnimation()
    {
        animator.SetTrigger("hide");
    }

    /// <summary>
    /// Set to Animation Event on Popup_Disappear animation to disactivated panel at the end of animation.
    /// </summary>
    private void DisactivePopupPanel()
    {
        this.gameObject.SetActive(false);
    }
}
