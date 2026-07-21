using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text;

public class ResultManager : MonoBehaviour
{
    [Header("Result UI")]
    public TMP_Text scoreText;
    public TMP_Text percentageText;
    public TMP_Text messageText;
    public TMP_Text correctText;
    public TMP_Text incorrectText;
    public TMP_Text reviewText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("QuizScore", 0);
        int total = PlayerPrefs.GetInt("QuizTotal", 0);

        scoreText.text = score + " / " + total;

        float percentage = 0;

        if (total > 0)
            percentage = ((float)score / total) * 100f;

        percentageText.text = percentage.ToString("F0") + "%";

        correctText.text = "✓ Correct Answers: " + score;
        incorrectText.text = "✗ Incorrect Answers: " + (total - score);

        // Colours
        correctText.color = Color.green;
        incorrectText.color = Color.red;

        if (score == total)
            messageText.text = "Excellent!";
        else if (percentage >= 70)
            messageText.text = "Great Job!";
        else if (percentage >= 50)
            messageText.text = "Good Effort!";
        else
            messageText.text = "Keep Practicing!";

        ShowReview();
    }

    void ShowReview()
    {
        int count = PlayerPrefs.GetInt("QuestionCount", 0);

        StringBuilder builder = new StringBuilder();

        builder.AppendLine("<color=red><b>Questions to Review</b></color>\n");

        bool hasWrong = false;

        for (int i = 0; i < count; i++)
        {
            int user =
                PlayerPrefs.GetInt("UserAnswer_" + i);

            int correct =
                PlayerPrefs.GetInt("CorrectAnswer_" + i);

            if (user != correct)
            {
                hasWrong = true;

                builder.AppendLine(
                    "<color=red>• Question " + (i + 1) + "</color>"
                );
            }
        }

        if (!hasWrong)
        {
            builder.Clear();

            builder.AppendLine(
                "<color=green><b>Perfect Score!</b></color>\n");

            builder.AppendLine(
                "<color=green>You answered every question correctly.</color>"
            );
        }

        reviewText.text = builder.ToString();
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