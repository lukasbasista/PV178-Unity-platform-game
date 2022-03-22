using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    
    /// <summary>
    /// Save player data to file from player object
    /// </summary>
    /// <param name="player">player object</param>
    public static void SavePlayer(Player player)
    {
        var formatter = new BinaryFormatter();
        var path = Application.persistentDataPath + "/player.txt";
        var stream = new FileStream(path, FileMode.Create);

        var data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    /// <summary>
    /// Save player data to file from Playerdata object
    /// </summary>
    /// <param name="data">playerdata object</param>
    public static void SavePlayer(PlayerData data)
    {
        var formatter = new BinaryFormatter();
        var path = Application.persistentDataPath + "/player.txt";
        var stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    
    /// <summary>
    /// Load player from file
    /// </summary>
    /// <returns>playerdata</returns>
    public static PlayerData LoadPlayer()
    {
        var path = Application.persistentDataPath + "/player.txt";
        if (File.Exists(path))
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);

            var data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Data file not exist");
            return null;
        }
    }
}