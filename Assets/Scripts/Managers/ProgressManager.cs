using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;

    private DatabaseReference database;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        database = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void SaveQuizResult(string muscle, int score, int totalQuestions)
    {
        if (UserSession.Instance == null)
            return;

        string userId = UserSession.Instance.UserId;

        float percentage = ((float)score / totalQuestions) * 100f;

        database.Child("Users")
            .Child(userId)
            .Child("QuizResults")
            .Child(muscle)
            .Child("Score")
            .SetValueAsync(score);

        database.Child("Users")
            .Child(userId)
            .Child("QuizResults")
            .Child(muscle)
            .Child("TotalQuestions")
            .SetValueAsync(totalQuestions);

        database.Child("Users")
            .Child(userId)
            .Child("QuizResults")
            .Child(muscle)
            .Child("Percentage")
            .SetValueAsync(percentage);

        database.Child("Users")
            .Child(userId)
            .Child("Progress")
            .Child("LastMuscle")
            .SetValueAsync(muscle);

        database.Child("Users")
            .Child(userId)
            .Child("Progress")
            .Child("HighestScore")
            .GetValueAsync()
            .ContinueWithOnMainThread(task =>
            {
                float highest = 0;

                if (task.Result.Exists)
                    highest = float.Parse(task.Result.Value.ToString());

                if (percentage > highest)
                {
                    database.Child("Users")
                        .Child(userId)
                        .Child("Progress")
                        .Child("HighestScore")
                        .SetValueAsync(percentage);
                }
            });

        database.Child("Users")
            .Child(userId)
            .Child("Progress")
            .Child("QuizzesCompleted")
            .RunTransaction(mutableData =>
            {
                int value = 0;

                if (mutableData.Value != null)
                    value = int.Parse(mutableData.Value.ToString());

                mutableData.Value = value + 1;

                return TransactionResult.Success(mutableData);
            });

        database.Child("Users")
            .Child(userId)
            .Child("Progress")
            .Child("TotalQuestionsAnswered")
            .RunTransaction(mutableData =>
            {
                int value = 0;

                if (mutableData.Value != null)
                    value = int.Parse(mutableData.Value.ToString());

                mutableData.Value = value + totalQuestions;

                return TransactionResult.Success(mutableData);
            });

        Debug.Log("Quiz Saved Successfully");
    }
}