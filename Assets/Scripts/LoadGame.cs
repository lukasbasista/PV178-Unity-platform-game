using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsynchronously());
    }

    /// <summary>
    /// Load next scene
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadAsynchronously()
    {
        var operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        var counter = 5;
        operation.allowSceneActivation = false;
        while (!operation.isDone || counter > 0)
        {
            if (counter <= 0)
            {
                operation.allowSceneActivation = true;
            }

            yield return new WaitForSeconds(1);
            counter--;
        }
    }
}