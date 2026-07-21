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

        // Initial button states
        previousButton.interactable = false;
        nextButton.interactable = false;
        submitButton.gameObject.SetActive(false);

        ShowQuestion();
    }

    void ShowQuestion()
    {
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

            // Reset button color
            ColorBlock colors = answerButtons[i].colors;
            colors.normalColor = Color.white;
            answerButtons[i].colors = colors;
        }

        // Restore previously selected answer
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
        previousButton.interactable = currentQuestion > 0;

        // Last Question
        if (currentQuestion == questions.Count - 1)
        {
            nextButton.gameObject.SetActive(false);
            submitButton.gameObject.SetActive(true);
        }
        else
        {
            nextButton.gameObject.SetActive(true);
            submitButton.gameObject.SetActive(false);
        }
    }

    void SelectAnswer(int answerIndex)
    {
        selectedAnswers[currentQuestion] = answerIndex;

        HighlightSelected(answerIndex);

        nextButton.interactable = true;
    }

   void HighlightSelected(int answerIndex)
{
    for (int i = 0; i < answerButtons.Length; i++)
    {
        Image img = answerButtons[i].GetComponent<Image>();

        if (i == answerIndex)
        {
            img.color = new Color(0.2f, 0.7f, 0.2f); // Green
        }
        else
        {
            img.color = Color.white;
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

        PlayerPrefs.Save();

        SceneManager.LoadScene("ResultScene");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("ARScene");
    }
}