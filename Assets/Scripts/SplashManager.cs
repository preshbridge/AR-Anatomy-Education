using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour
{
    [SerializeField] private float splashDuration = 3f;

    private void Start()
    {
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(splashDuration);
        SceneManager.LoadScene("OnboardingScene");
    }
}