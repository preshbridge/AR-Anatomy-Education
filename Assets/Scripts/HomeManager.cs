using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class HomeManager : MonoBehaviour
{
    public TMP_Text totalQuestionsText;
    public TMP_Text averageScoreText;
    public TMP_Text progressText;

    void Start()
    {
        LoadQuizData();
    }

    void LoadQuizData()
    {
        int totalQuestions = PlayerPrefs.GetInt("TotalQuestionsAnswered", 0);

        float averageScore = PlayerPrefs.GetFloat("AverageScore", 0);

        totalQuestionsText.text = totalQuestions.ToString();

        averageScoreText.text = averageScore.ToString("F0") + "%";

        if (totalQuestions == 0)
        {
            progressText.text =
                "You haven't started any quiz yet.\nStart learning now!";
        }
        else
        {
            progressText.text =
                "Great job!\nKeep learning to improve your score.";
        }
    }

    // Open Study Scene
public void OpenStudy()
{
    SceneManager.LoadScene("StudyScene");
}

// Open AR Scene
public void OpenAR()
{
    SceneManager.LoadScene("ARScene");
}

// Open Quiz Scene
public void OpenQuiz()
{
    SceneManager.LoadScene("QuizScene");
}
}