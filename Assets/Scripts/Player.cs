using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 1;
    public int character;

    private void Start()
    {
        LoadPlayer();
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("selectedCharacter", character);
    }

    /// <summary>
    /// Save player data to File
    /// </summary>
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    /// <summary>
    /// Load player data from file
    /// </summary>
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        level = data.level;
        character = data.character;
    }

    /// <summary>
    /// Reset player data
    /// </summary>
    public void Reset()
    {
        level = 1;
        character = 0;
        SaveSystem.SavePlayer(this);
    }
}