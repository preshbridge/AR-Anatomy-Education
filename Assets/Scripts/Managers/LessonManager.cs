using UnityEngine;
using TMPro;

public class LessonManager : MonoBehaviour
{
    [Header("Lesson Panels")]
    public GameObject shoulderLessonPanel;
    public GameObject upperArmLessonPanel;
    public GameObject forearmLessonPanel;

    [Header("Shoulder UI")]
    public TMP_Text muscleTitle;
    public TMP_Text descriptionText;
    public TMP_Text functionText;
    public TMP_Text locationText;

    void Start()
    {
        ShowCorrectPanel();
        LoadLesson();
    }

    void ShowCorrectPanel()
    {
        // Hide all panels first
        shoulderLessonPanel.SetActive(false);
        upperArmLessonPanel.SetActive(false);
        forearmLessonPanel.SetActive(false);

        // Show the correct panel based on the selected muscle group
        switch (AppManager.Instance.SelectedMuscleGroup)
        {
            case "Shoulder":
                shoulderLessonPanel.SetActive(true);
                break;

            case "Upper Arm":
                upperArmLessonPanel.SetActive(true);
                break;

            case "Forearm":
                forearmLessonPanel.SetActive(true);
                break;

            default:
                shoulderLessonPanel.SetActive(true);
                break;
        }
    }

    void LoadLesson()
    {
        switch (AppManager.Instance.SelectedMuscle)
        {
            case "Deltoid":
                muscleTitle.text = "Deltoid";
                descriptionText.text = "The deltoid is a large triangular muscle covering the shoulder joint. It is responsible for lifting, rotating, and stabilizing the arm during movement.";
                functionText.text = "• Raises the arm\n• Rotates the shoulder\n• Stabilizes the shoulder joint";
                locationText.text = "Shoulder Region";
                break;

            case "Supraspinatus":
                muscleTitle.text = "Supraspinatus";
                descriptionText.text = "The supraspinatus is a small muscle located at the top of the shoulder blade. It helps lift the arm away from the body.";
                functionText.text = "• Initiates arm abduction\n• Stabilizes the shoulder joint";
                locationText.text = "Upper Scapula";
                break;

            case "Infraspinatus":
                muscleTitle.text = "Infraspinatus";
                descriptionText.text = "The infraspinatus is a broad muscle on the back of the shoulder blade that rotates the arm outward.";
                functionText.text = "• External rotation\n• Stabilizes the shoulder";
                locationText.text = "Posterior Scapula";
                break;

            case "Teres Minor":
                muscleTitle.text = "Teres Minor";
                descriptionText.text = "The teres minor is a narrow rotator cuff muscle that supports shoulder stability.";
                functionText.text = "• External rotation\n• Shoulder stabilization";
                locationText.text = "Lateral Border of Scapula";
                break;

            case "Subscapularis":
                muscleTitle.text = "Subscapularis";
                descriptionText.text = "The subscapularis is the largest rotator cuff muscle. It rotates the arm inward.";
                functionText.text = "• Internal rotation\n• Stabilizes the shoulder";
                locationText.text = "Anterior Scapula";
                break;

            default:
                muscleTitle.text = "Muscle Not Found";
                descriptionText.text = "";
                functionText.text = "";
                locationText.text = "";
                break;
        }
    }
}