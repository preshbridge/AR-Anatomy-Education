using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LessonManager : MonoBehaviour
{
    [Header("Lesson Panels")]
    public GameObject shoulderLessonPanel;
    public GameObject upperArmLessonPanel;
    public GameObject forearmLessonPanel;

    [Header("Lesson UI")]
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
            //======================
            // SHOULDER
            //======================

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

            //======================
            // UPPER ARM
            //======================

            case "Biceps Brachii":
                muscleTitle.text = "Biceps Brachii";
                descriptionText.text = "The biceps brachii is a two-headed muscle located at the front of the upper arm. It bends the elbow and rotates the forearm.";
                functionText.text = "• Flexes the elbow\n• Supinates the forearm\n• Assists shoulder flexion";
                locationText.text = "Anterior Upper Arm";
                break;

            case "Brachialis":
                muscleTitle.text = "Brachialis";
                descriptionText.text = "The brachialis lies beneath the biceps brachii and is the strongest elbow flexor.";
                functionText.text = "• Flexes the elbow\n• Provides strength during lifting";
                locationText.text = "Anterior Upper Arm";
                break;

            case "Coracobrachialis":
                muscleTitle.text = "Coracobrachialis";
                descriptionText.text = "The coracobrachialis is a slender muscle that helps move the arm forward and toward the body.";
                functionText.text = "• Flexes the shoulder\n• Adducts the arm\n• Stabilizes the shoulder";
                locationText.text = "Medial Upper Arm";
                break;

            case "Triceps Brachii":
                muscleTitle.text = "Triceps Brachii";
                descriptionText.text = "The triceps brachii is the large muscle on the back of the upper arm responsible for straightening the elbow.";
                functionText.text = "• Extends the elbow\n• Assists shoulder extension";
                locationText.text = "Posterior Upper Arm";
                break;

            //======================
            // FOREARM
            //======================

            case "Brachioradialis":
                muscleTitle.text = "Brachioradialis";
                descriptionText.text = "The brachioradialis is a forearm muscle that bends the elbow, especially when the hand is in a neutral position.";
                functionText.text = "• Flexes the elbow\n• Assists forearm rotation";
                locationText.text = "Lateral Forearm";
                break;

            case "Flexor Carpi Radialis":
                muscleTitle.text = "Flexor Carpi Radialis";
                descriptionText.text = "This muscle bends the wrist and moves the hand toward the thumb side.";
                functionText.text = "• Flexes the wrist\n• Abducts the hand";
                locationText.text = "Anterior Forearm";
                break;

            case "Palmaris Longus":
                muscleTitle.text = "Palmaris Longus";
                descriptionText.text = "The palmaris longus assists wrist flexion and tightens the palm. It is absent in some individuals.";
                functionText.text = "• Flexes the wrist\n• Tightens the palmar fascia";
                locationText.text = "Anterior Forearm";
                break;

            case "Flexor Carpi Ulnaris":
                muscleTitle.text = "Flexor Carpi Ulnaris";
                descriptionText.text = "The flexor carpi ulnaris bends the wrist and moves the hand toward the little finger.";
                functionText.text = "• Flexes the wrist\n• Adducts the hand";
                locationText.text = "Medial Forearm";
                break;

            default:
                muscleTitle.text = "Muscle Not Found";
                descriptionText.text = "";
                functionText.text = "";
                locationText.text = "";
                break;
        }
    }

    //======================
    // BACK BUTTON
    //======================

    public void GoBack()
    {
        SceneManager.LoadScene("TopicScene");
    }
}