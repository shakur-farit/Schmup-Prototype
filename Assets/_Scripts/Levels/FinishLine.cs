using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.instance != null)
        {
            if (collision.gameObject.tag == "Player" && GameManager.instance.GetComponent<LevelWinnable>().isLevelWinnableWithAccrosFinishLine)
            {
                GameManager.instance.GetComponent<GameEvents>().LevelComplite();
            }
        }
        else
            Debug.LogWarning("There is no game manager in the scene, there needs to be one for correctly work of finish line.");
    }
}
