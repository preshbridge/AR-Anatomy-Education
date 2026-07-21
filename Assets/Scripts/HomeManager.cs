using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Firebase.Database;
using Firebase.Extensions;

public class HomeManager : MonoBehaviour
{
    [Header("UI")]
    
    public TMP_Text totalQuestionsText;
    public TMP_Text averageScoreText;
    public TMP_Text progressText;

    DatabaseReference database;

    void Start()
    {
        database = FirebaseDatabase.DefaultInstance.RootReference;

        LoadQuizData();
    }

    void LoadQuizData()
    {
        if (UserSession.Instance == null)
            return;

        string userId = UserSession.Instance.UserId;

        database.Child("Users")
        .Child(userId)
        .GetValueAsync()
        .ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || !task.Result.Exists)
            {
                Debug.Log("No user data found.");
                return;
            }

            DataSnapshot user = task.Result;

            // Total Questions
            if (user.Child("Progress").Child("TotalQuestionsAnswered").Exists)
            {
                totalQuestionsText.text =
                user.Child("Progress")
                .Child("TotalQuestionsAnswered")
                .Value.ToString();
            }
            else
            {
                totalQuestionsText.text = "0";
            }

            // Highest Score
            if (user.Child("Progress").Child("HighestScore").Exists)
            {
                float highest =
                float.Parse(user.Child("Progress")
                .Child("HighestScore")
                .Value.ToString());

                averageScoreText.text = highest.ToString("F0") + "%";
            }
            else
            {
                averageScoreText.text = "0%";
            }

            // Progress Message
            if (user.Child("Progress").Child("LastMuscle").Exists)
            {
                string muscle =
                user.Child("Progress")
                .Child("LastMuscle")
                .Value.ToString();

                progressText.text =
                "Highest Progress:\n" +
                muscle +
                "\nKeep learning!";
            }
            else
            {
                progressText.text =
                "You haven't started any quiz yet.\nStart learning now!";
            }
        });
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