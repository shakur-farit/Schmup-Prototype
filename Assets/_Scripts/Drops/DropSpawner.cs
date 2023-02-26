using UnityEngine;

/// <summary>
/// This class spawn drop.
/// </summary>
public class DropSpawner : MonoBehaviour
{
    [Header("Drop's Component")]
    [Tooltip("Prefab of drop.")]
    public GameObject dropPrefab;
    [Tooltip("Whether this object drop or not.")]
    public bool hasDrop = false;
    GameObject gameContainer;


    private void Start()
    {
        FindGameContainer();
    }


    /// <summary>
    /// Spawn randomly drop.
    /// </summary>
    public void SpawnDrop()
    {
        if (hasDrop)
        { 
            GameObject drop = Instantiate(dropPrefab, transform.position, Quaternion.identity);

            // Instantiate random drop.
            dropPrefab.GetComponent<Drop>().dropMode = (DropsModes)Random.Range(0, 8);

            switch (dropPrefab.GetComponent<Drop>().dropMode)
            {
                case DropsModes.Shield:
                    dropPrefab.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    break;
                case DropsModes.SmallHeal:
                    dropPrefab.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.13f, 0.80f, 0.04f,1f);
                    break;
                case DropsModes.LargeHeal:
                    dropPrefab.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.09f, 0.51f, 0.51f, 1f);
                    break;
                case DropsModes.MachinegunWeapon:
                    dropPrefab.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.63f, 0.14f, 0.06f,1f);
                    break;
                case DropsModes.FireballWeapon:
                    dropPrefab.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.94f, 0.35f, 0.20f, 1f);
                    break;
                case DropsModes.LazerWeapon:
                    dropPrefab.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.84f, 0.37f, 0.11f, 1f);
                    break;
                case DropsModes.WeaponPowerLevelOne:
                    dropPrefab.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.59f, 0.54f, 0.91f, 1f);
                    break;
                case DropsModes.WeaponPowerLevelTwo:
                    dropPrefab.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.28f, 0.28f, 0.83f, 1f);
                    break;
                case DropsModes.WeaponPowerLevelThree:
                    dropPrefab.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.15f, 0.15f, 0.75f, 1f);
                    break;
            }

            if (gameContainer != null)
                drop.gameObject.transform.SetParent(gameContainer.transform);
        }
    }

    /// <summary>
    /// Attempts to find ProjectileHolder in hierarchy to hold projectiles.
    /// </summary>
    private void FindGameContainer()
    {
        if (gameContainer == null)
        {
            gameContainer = GameObject.Find("GameContainer");

            if (gameContainer == null)
            {
                Debug.Log("Create the Empty Object with \"GameContainer\" name to hold drops in it. ");
            }
        }
    }
}
