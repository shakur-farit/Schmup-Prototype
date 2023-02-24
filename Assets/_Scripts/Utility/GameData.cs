using UnityEngine;

/// <summary>
/// This class saves game data
/// </summary>
public class GameData : DontDestroyOnLoadObject<GameData>
{

    // How much level was complet.
    private int completedLevelIndex;

    // Muted or not Background Sounds.
    [HideInInspector]
    public bool backgroundSoundIsMuted = false;
    // Muted or not Game Sounds.
    [HideInInspector]
    public bool gameSoundIsMuted = false;


    public int CompletedLevelIndex { get { return completedLevelIndex; } set { completedLevelIndex = value; } }
}
