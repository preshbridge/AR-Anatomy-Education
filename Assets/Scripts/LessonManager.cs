using UnityEngine;
using TMPro;

public class LessonManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text muscleTitle;
    public TMP_Text descriptionText;
    public TMP_Text functionText;
    public TMP_Text locationText;

    void Start()
    {
        LoadLesson();
    }

    void LoadLesson()
    {
        switch (MuscleSelectionManager.SelectedMuscle)
        {
            case "Deltoid":
                muscleTitle.text = "Deltoid";
                descriptionText.text = "The deltoid is a large triangular muscle covering the shoulder joint.";
                functionText.text = "• Raises the arm\n• Stabilizes the shoulder\n• Assists shoulder movement";
                locationText.text = "Shoulder";
                break;

            default:
                muscleTitle.text = "Select a Muscle";
                descriptionText.text = "";
                functionText.text = "";
                locationText.text = "";
                break;
        }
    }
}