using UnityEngine;


/// <summary>
/// This class makes child class to Don't Destroy To Load.
/// </summary>
/// <typeparam name="T"></typeparam>
public class DontDestroyOnLoadObject<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance { get { return instance; } }


    protected virtual void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this as T;
            DontDestroyOnLoad(this);
        }
    }
}
