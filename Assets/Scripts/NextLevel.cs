using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject loadingScreen;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        var index = SceneManager.GetActiveScene().buildIndex;
        if (index >= SceneManager.sceneCountInBuildSettings - 1)
        {
            StartCoroutine(LoadAsynchronously(1));
            return;
        }

        StartCoroutine(LoadAsynchronously(index + 1));
    }

    IEnumerator LoadAsynchronously(int index)
    {
        loadingScreen.SetActive(true);
        var operation = SceneManager.LoadSceneAsync(index);
        if (PlayerPrefs.GetInt("level") < index - 1)
        {
            var data = SaveSystem.LoadPlayer();
            data.level = index - 1;
            SaveSystem.SavePlayer(data);
            PlayerPrefs.SetInt("level", index - 1);
        }

        while (!operation.isDone)
        {
            yield return null;
        }
    }
}