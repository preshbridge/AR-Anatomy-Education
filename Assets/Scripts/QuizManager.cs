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
        string muscle = AppManager.Instance.SelectedMuscle;

        if (muscle == "Deltoid")
        {
            questions = new Question[]
            {
                new Question("What is the primary function of the Deltoid?",
                    new string[]{"Arm Abduction","Knee Flexion","Finger Extension","Neck Rotation"},0),

                new Question("Where is the Deltoid located?",
                    new string[]{"Shoulder","Forearm","Chest","Leg"},0),

                new Question("The Deltoid helps with?",
                    new string[]{"Lifting the arm","Walking","Blinking","Breathing"},0),

                new Question("The Deltoid is a ____ muscle.",
                    new string[]{"Shoulder","Forearm","Back","Hip"},0),

                new Question("The Deltoid stabilizes the?",
                    new string[]{"Shoulder Joint","Elbow","Knee","Ankle"},0)
            };
        }

        else if (muscle == "Biceps Brachii")
        {
            questions = new Question[]
            {
                new Question("The Biceps mainly performs?",
                    new string[]{"Elbow Flexion","Knee Extension","Wrist Rotation","Hip Flexion"},0),

                new Question("The Biceps is found in the?",
                    new string[]{"Upper Arm","Forearm","Leg","Chest"},0),

                new Question("The Biceps helps in?",
                    new string[]{"Supination","Breathing","Walking","Chewing"},0),

                new Question("The Biceps has how many heads?",
                    new string[]{"Two","One","Three","Four"},0),

                new Question("The Biceps crosses the?",
                    new string[]{"Shoulder and Elbow","Knee","Ankle","Hip"},0)
            };
        }

        else
        {
            questions = new Question[]
            {
                new Question(
                    "Where is the " + muscle + " located?",
                    new string[]{
                        "Correct Region",
                        "Leg",
                        "Neck",
                        "Foot"
                    },
                    0)
            };
        }
    }

    void ShowQuestion()
    {
        if(currentQuestion >= questions.Length)
        {
            PlayerPrefs.SetInt("QuizScore", score);
            PlayerPrefs.SetInt("QuizTotal", questions.Length);

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
}