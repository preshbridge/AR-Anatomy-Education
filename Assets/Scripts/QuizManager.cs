using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text questionText;
    public Button[] answerButtons;
    public TMP_Text[] answerTexts;

    private int currentQuestion = 0;
    private int score = 0;

    Question[] questions;

    void Start()
    {
        LoadQuestions();
        ShowQuestion();
    }
void LoadQuestions()
{
    questions = QuestionDatabase
        .GetQuestions(AppManager.Instance.SelectedMuscle)
        .ToArray();
}
    
    void ShowQuestion()
    {
        if(currentQuestion >= questions.Length)
        {
            PlayerPrefs.SetInt("QuizScore", score);
PlayerPrefs.SetInt("QuizTotal", questions.Length);

PlayerPrefs.SetInt("TotalQuestionsAnswered", questions.Length);

float average =
((float)score / questions.Length) * 100f;

PlayerPrefs.SetFloat("AverageScore", average);

PlayerPrefs.Save();

            SceneManager.LoadScene("ResultScene");
            return;
        }

        questionText.text = questions[currentQuestion].question;

        for(int i=0;i<4;i++)
        {
            answerTexts[i].text = questions[currentQuestion].answers[i];

            int index = i;

            answerButtons[i].onClick.RemoveAllListeners();

            answerButtons[i].onClick.AddListener(() =>
            {
                CheckAnswer(index);
            });
        }
    }

    void CheckAnswer(int answer)
    {
        if(answer == questions[currentQuestion].correctAnswer)
        {
            score++;
        }

        currentQuestion++;

        ShowQuestion();
    }

    public void GoBack()
{
    SceneManager.LoadScene("ARScene");
}
}