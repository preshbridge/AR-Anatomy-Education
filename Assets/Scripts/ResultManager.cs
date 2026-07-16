using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text messageText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("QuizScore");
        int total = PlayerPrefs.GetInt("QuizTotal");

        scoreText.text = score + " / " + total;

        if (score == total)
            messageText.text = "Excellent!";
        else if (score >= total * 0.7f)
            messageText.text = "Great Job!";
        else if (score >= total * 0.5f)
            messageText.text = "Good Effort!";
        else
            messageText.text = "Keep Practicing!";
    }

    public void Home()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void StudyAgain()
    {
        SceneManager.LoadScene("StudyScene");
    }
}