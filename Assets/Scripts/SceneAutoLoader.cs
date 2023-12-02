using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneAutoLoader : MonoBehaviour
{
    public float delayInSeconds = 20f;

    void Start()
    {
        StartCoroutine(DelayedLoadScene("Main Menu", delayInSeconds));
    }

    IEnumerator DelayedLoadScene(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
