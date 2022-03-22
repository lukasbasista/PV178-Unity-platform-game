using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject p;
    public int selectedCharacter;

    private void OnEnable()
    {
        selectedCharacter = p.GetComponent<Player>().character;
        foreach (var ch in characters)
        {
            ch.SetActive(false);
        }

        characters[selectedCharacter].SetActive(true);
    }


    /// <summary>
    /// Display next skin
    /// </summary>
    public void NextSkin()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    
    /// <summary>
    /// Display previous skin
    /// </summary>
    public void PreviousSkin()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }

        characters[selectedCharacter].SetActive(true);
    }

    /// <summary>
    /// Save selected skin
    /// </summary>
    public void PlayGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        p.GetComponent<Player>().character = selectedCharacter;
        p.GetComponent<Player>().SavePlayer();
    }
}