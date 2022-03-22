using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    public GameObject loadingScreen;
    private GameObject[] _players;

    [FormerlySerializedAs("GameIsPaused")] public bool gameIsPaused;
    [FormerlySerializedAs("PauseMenu")] public GameObject pauseMenu;
    [FormerlySerializedAs("MenuButton")] public GameObject menuButton;

    private void OnEnable()
    {
        Time.timeScale = 1f;
        Debug.Log(PlayerPrefs.GetInt("selectedCharacter").ToString());
        var selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        var prefab = characterPrefabs[selectedCharacter];
        _players = GameObject.FindGameObjectsWithTag("Player");
        if (_players.Length < 1)
        {
            var clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        }
    }

    private void LateUpdate()
    {
        if (!Input.GetButtonDown("Cancel")) return;
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    /// <summary>
    /// Destroy player and load main menu
    /// </summary>
    public void ExitToMainMenu()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadSceneAsync(1);
        var players = GameObject.FindWithTag("Player");
        Destroy(players);
    }

    /// <summary>
    /// Resume to game
    /// </summary>
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        menuButton.SetActive(true);
        gameIsPaused = false;
    }

    /// <summary>
    /// Pause game
    /// </summary>
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        menuButton.SetActive(false);
        gameIsPaused = true;
    }

    /// <summary>
    /// Restart game
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}