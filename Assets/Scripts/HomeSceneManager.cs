using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneManager : MonoBehaviour
{
    public void OpenHome()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void OpenStudy()
    {
        SceneManager.LoadScene("StudyScene");
    }

    public void OpenAR()
    {
        SceneManager.LoadScene("ARScene");
    }

    public void OpenQuiz()
    {
        SceneManager.LoadScene("QuizScene");
    }

    public void OpenProfile()
    {
        SceneManager.LoadScene("ProfileScene");
    }
}