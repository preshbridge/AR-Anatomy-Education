using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSignUpScene()
    {
        SceneManager.LoadScene("SignUpScene");
    }

    public void LoadLoginScene()
    {
        SceneManager.LoadScene("LoginScene");
    }

    public void LoadHomeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void LoadOnboardingScene()
    {
        SceneManager.LoadScene("OnboardingScene");
    }
}