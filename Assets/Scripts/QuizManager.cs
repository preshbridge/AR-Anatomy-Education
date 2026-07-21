using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text questionCounter;
    public TMP_Text questionText;

    public Button[] answerButtons;
    public TMP_Text[] answerTexts;

    public Button previousButton;
    public Button nextButton;
    public Button submitButton;

    private List<Question> questions;

    private int currentQuestion = 0;
    private int[] selectedAnswers;

    void Start()
    {
        // Load questions for the selected muscle
        questions = QuestionDatabase.GetQuestions(AppManager.Instance.SelectedMuscle);

        // Initialize answer storage
        selectedAnswers = new int[questions.Count];

        for (int i = 0; i < selectedAnswers.Length; i++)
            selectedAnswers[i] = -1;

        previousButton.interactable = false;
        nextButton.interactable = false;
        submitButton.gameObject.SetActive(false);

        ShowQuestion();
    }

    void ShowQuestion()
    {
        // Reset all button colours first
        ResetButtonColors();

        // Update Question Counter
        questionCounter.text = "Question " + (currentQuestion + 1) + " of " + questions.Count;

        // Display Question
        questionText.text = questions[currentQuestion].question;

        // Display Answers
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerTexts[i].text = questions[currentQuestion].answers[i];

            int index = i;

            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() =>
            {
                SelectAnswer(index);
            });
        }

        // Restore answer only if this question has been answered before
        if (selectedAnswers[currentQuestion] != -1)
        {
            HighlightSelected(selectedAnswers[currentQuestion]);
            nextButton.interactable = true;
        }
        else
        {
            nextButton.interactable = false;
        }

        // Previous Button
        previousButton.gameObject.SetActive(true);
        previousButton.interactable = (currentQuestion > 0);

        // Next / Submit Buttons
if (currentQuestion == questions.Count - 1)
{
    // LAST QUESTION
    nextButton.gameObject.SetActive(false);

    submitButton.gameObject.SetActive(true);

    // Only allow submit after selecting an answer
    submitButton.interactable = (selectedAnswers[currentQuestion] != -1);
}
else
{
    // ALL OTHER QUESTIONS
    nextButton.gameObject.SetActive(true);
    nextButton.interactable = (selectedAnswers[currentQuestion] != -1);

    submitButton.gameObject.SetActive(false);
}

   void SelectAnswer(int answerIndex)
{
    selectedAnswers[currentQuestion] = answerIndex;

    HighlightSelected(answerIndex);

    if (currentQuestion == questions.Count - 1)
    {
        submitButton.interactable = true;
    }
    else
    {
        nextButton.interactable = true;
    }
}
    void HighlightSelected(int answerIndex)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image image = answerButtons[i].GetComponent<Image>();

            if (i == answerIndex)
            {
                image.color = new Color32(46, 204, 113, 255); // Green
            }
            else
            {
                image.color = Color.white;
            }
        }
    }

    void ResetButtonColors()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image image = answerButtons[i].GetComponent<Image>();
            image.color = Color.white;
        }
    }
    }
    public void NextQuestion()
    {
        if (currentQuestion < questions.Count - 1)
        {
            currentQuestion++;
            ShowQuestion();
        }
    }

    public void PreviousQuestion()
    {
        if (currentQuestion > 0)
        {
            currentQuestion--;
            ShowQuestion();
        }
    }

    public void SubmitQuiz()
{
    // Prevent double tap on Android
    Debug.Log("SUBMIT BUTTON PRESSED");
    submitButton.interactable = false;

    int score = 0;

    for (int i = 0; i < questions.Count; i++)
    {
        if (selectedAnswers[i] == questions[i].correctAnswer)
            score++;
    }

    PlayerPrefs.SetInt("QuizScore", score);
    PlayerPrefs.SetInt("QuizTotal", questions.Count);
    PlayerPrefs.SetInt("TotalQuestionsAnswered", questions.Count);

    float average = ((float)score / questions.Count) * 100f;
    PlayerPrefs.SetFloat("AverageScore", average);

    string muscle = AppManager.Instance.SelectedMuscle;

    if (muscle == "Deltoid" ||
        muscle == "Supraspinatus" ||
        muscle == "Infraspinatus" ||
        muscle == "Teres Minor" ||
        muscle == "Subscapularis")
    {
        float oldScore = PlayerPrefs.GetFloat("ShoulderProgress", 0);

        if (average > oldScore)
            PlayerPrefs.SetFloat("ShoulderProgress", average);
    }
    else if (muscle == "Biceps Brachii" ||
             muscle == "Brachialis" ||
             muscle == "Coracobrachialis" ||
             muscle == "Triceps Brachii")
    {
        float oldScore = PlayerPrefs.GetFloat("UpperArmProgress", 0);

        if (average > oldScore)
            PlayerPrefs.SetFloat("UpperArmProgress", average);
    }
    else if (muscle == "Brachioradialis" ||
             muscle == "Flexor Carpi Radialis" ||
             muscle == "Palmaris Longus" ||
             muscle == "Flexor Carpi Ulnaris")
    {
        float oldScore = PlayerPrefs.GetFloat("ForearmProgress", 0);

        if (average > oldScore)
            PlayerPrefs.SetFloat("ForearmProgress", average);
    }

    ProgressManager.Instance.SaveQuizResult(
        AppManager.Instance.SelectedMuscle,
        score,
        questions.Count
    );

    PlayerPrefs.SetInt("QuestionCount", questions.Count);

    for (int i = 0; i < questions.Count; i++)
    {
        PlayerPrefs.SetInt("UserAnswer_" + i, selectedAnswers[i]);
        PlayerPrefs.SetInt("CorrectAnswer_" + i, questions[i].correctAnswer);

        PlayerPrefs.SetString("Question_" + i, questions[i].question);

        PlayerPrefs.SetString("Option0_" + i, questions[i].answers[0]);
        PlayerPrefs.SetString("Option1_" + i, questions[i].answers[1]);
        PlayerPrefs.SetString("Option2_" + i, questions[i].answers[2]);
        PlayerPrefs.SetString("Option3_" + i, questions[i].answers[3]);
    }

    PlayerPrefs.Save();

    SceneManager.LoadScene("ResultScene");
}
    public void GoBack()
    {
        SceneManager.LoadScene("ARScene");
    }
}