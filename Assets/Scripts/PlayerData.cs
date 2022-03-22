[System.Serializable]
public class PlayerData
{
    public int level;
    public int character;

    public PlayerData(Player player)
    {
        level = player.level;
        character = player.character;
    }

    public PlayerData(int level, int character)
    {
        this.level = level;
        this.character = character;
    }
}