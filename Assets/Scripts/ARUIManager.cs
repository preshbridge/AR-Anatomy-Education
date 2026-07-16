using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ARUIManager : MonoBehaviour
{
    public ARPlacementManager placementManager;

    [Header("UI")]
    public TMP_Text muscleTitle;

    void Start()
    {
        // Display the selected muscle name
        if (AppManager.Instance != null)
        {
            muscleTitle.text = AppManager.Instance.SelectedMuscle;
        }
    }

    // Back to Lesson Scene
    public void BackToLesson()
    {
        SceneManager.LoadScene("LessonScene");
    }

    // Open Quiz Scene
    public void OpenQuiz()
    {
        SceneManager.LoadScene("QuizScene");
    }

    // Reload the AR Scene (acts as Reset)
   public void ResetModel()
{
    placementManager.ResetPlacement();
}
}