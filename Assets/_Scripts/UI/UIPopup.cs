using UnityEngine;

/// <summary>
/// This class mark popup panel and close it.
/// </summary>
public class UIPopup : MonoBehaviour
{
    [Tooltip("Index of the Popup Panel.")]
    public string popupPanelName;

    private Animator animator;

    private GameObject levelMapOne;



    private void OnEnable()
    {
        GameEvents.OnBackButton += PlayPopupDisappearAnimation;
    }

    private void OnDisable()
    {
        GameEvents.OnBackButton -= PlayPopupDisappearAnimation;
    }

    private void Awake()
    {
        SetUpPopupGameObjects();
    }

    private void Start()
    {
        // Disable popup panel on application starting.
        gameObject.SetActive(false);

        animator = GetComponent<Animator>();
    }


    /// <summary>
    /// Trigger "hide" parameter to play Popup_Disappear animation clip. 
    /// </summary>
    private void PlayPopupDisappearAnimation()
    {
        // If UIPopupLevelMap1 popup panel(game object) is active.
        if (levelMapOne != null && levelMapOne.activeInHierarchy == true)
        {
            // Play Popup_Disappear animation clip and return form method.
            levelMapOne.GetComponent<Animator>().SetTrigger("hide");
            return;           
        }
        else
        {
            print("is hide");
            animator.SetTrigger("hide");
        }
    }

    /// <summary>
    /// Set to Animation Event on Popup_Disappear animation to disactivated panel at the end of animation.
    /// </summary>
    private void DisactivePopupPanel()
    {
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// Set up popup game objects that must close in turn.
    /// </summary>
    private void SetUpPopupGameObjects()
    {
        levelMapOne = GameObject.Find("UIPopupLevelMap1");
    }

}
