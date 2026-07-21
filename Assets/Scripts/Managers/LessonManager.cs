using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LessonManager : MonoBehaviour
{
    [Header("Lesson Panels")]
    public GameObject shoulderLessonPanel;
    public GameObject upperArmLessonPanel;
    public GameObject forearmLessonPanel;
//==============================
// SHOULDER PANEL
//==============================

[Header("Shoulder UI")]
public TMP_Text shoulderMuscleTitle;
public TMP_Text shoulderDescriptionText;
public TMP_Text shoulderFunctionText;
public TMP_Text shoulderLocationText;


//==============================
// UPPER ARM PANEL
//==============================

[Header("Upper Arm UI")]
public TMP_Text upperArmMuscleTitle;
public TMP_Text upperArmDescriptionText;
public TMP_Text upperArmFunctionText;
public TMP_Text upperArmLocationText;


//==============================
// FOREARM PANEL
//==============================

[Header("Forearm UI")]
public TMP_Text forearmMuscleTitle;
public TMP_Text forearmDescriptionText;
public TMP_Text forearmFunctionText;
public TMP_Text forearmLocationText;

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
               shoulderMuscleTitle.text = "Deltoid";
                shoulderDescriptionText.text = "The deltoid is a large triangular muscle covering the shoulder joint. It is responsible for lifting, rotating, and stabilizing the arm during movement.";
                shoulderFunctionText.text = "• Raises the arm\n• Rotates the shoulder\n• Stabilizes the shoulder joint";
                shoulderLocationText.text = "Shoulder Region";
                break;

            case "Supraspinatus":
                shoulderMuscleTitle.text = "Supraspinatus";
                shoulderDescriptionText.text = "The supraspinatus is a small muscle located at the top of the shoulder blade. It helps lift the arm away from the body.";
                shoulderFunctionText.text = "• Initiates arm abduction\n• Stabilizes the shoulder joint";
                shoulderLocationText.text = "Upper Scapula";
                break;

            case "Infraspinatus":
                shoulderMuscleTitle.text = "Infraspinatus";
                shoulderDescriptionText.text = "The infraspinatus is a broad muscle on the back of the shoulder blade that rotates the arm outward.";
                shoulderFunctionText.text = "• External rotation\n• Stabilizes the shoulder";
                shoulderLocationText.text = "Posterior Scapula";
                break;

            case "Teres Minor":
                shoulderMuscleTitle.text = "Teres Minor";
                shoulderDescriptionText.text = "The teres minor is a narrow rotator cuff muscle that supports shoulder stability.";
                shoulderFunctionText.text = "• External rotation\n• Shoulder stabilization";
                shoulderLocationText.text = "Lateral Border of Scapula";
                break;

            case "Subscapularis":
                shoulderMuscleTitle.text = "Subscapularis";
                shoulderDescriptionText.text = "The subscapularis is the largest rotator cuff muscle. It rotates the arm inward.";
                shoulderFunctionText.text = "• Internal rotation\n• Stabilizes the shoulder";
                shoulderLocationText.text = "Anterior Scapula";
                break;

            //======================
            // UPPER ARM
            //======================

            case "Biceps Brachii":
                upperArmMuscleTitle.text = "Biceps Brachii";
                upperArmDescriptionText.text = "The biceps brachii is a two-headed muscle located at the front of the upper arm. It bends the elbow and rotates the forearm.";
                upperArmFunctionText.text = "• Flexes the elbow\n• Supinates the forearm\n• Assists shoulder flexion";
                upperArmLocationText.text = "Anterior Upper Arm";
                break;

            case "Brachialis":
                upperArmMuscleTitle.text = "Brachialis";
                upperArmDescriptionText.text = "The brachialis lies beneath the biceps brachii and is the strongest elbow flexor.";
                upperArmFunctionText.text = "• Flexes the elbow\n• Provides strength during lifting";
                upperArmLocationText.text = "Anterior Upper Arm";
                break;

            case "Coracobrachialis":
                upperArmMuscleTitle.text = "Coracobrachialis";
                upperArmDescriptionText.text = "The coracobrachialis is a slender muscle that helps move the arm forward and toward the body.";
                upperArmFunctionText.text = "• Flexes the shoulder\n• Adducts the arm\n• Stabilizes the shoulder";
                upperArmLocationText.text = "Medial Upper Arm";
                break;

            case "Triceps Brachii":
                upperArmMuscleTitle.text = "Triceps Brachii";
                upperArmDescriptionText.text = "The triceps brachii is the large muscle on the back of the upper arm responsible for straightening the elbow.";
                upperArmFunctionText.text = "• Extends the elbow\n• Assists shoulder extension";
                upperArmLocationText.text = "Posterior Upper Arm";
                break;

            //======================
            // FOREARM
            //======================

            case "Brachioradialis":
    forearmMuscleTitle.text = "Brachioradialis";

    forearmDescriptionText.text =
        "The brachioradialis is a superficial muscle located on the lateral side of the forearm. It is most active when the forearm is in a neutral (thumb-up) position and plays an important role in elbow flexion.";

    forearmFunctionText.text =
        "• Flexes the elbow\n" +
        "• Assists in pronation and supination to return the forearm to the neutral position\n" +
        "• Helps stabilize the elbow during movement";

    forearmLocationText.text =
        "Lateral Forearm\n" +
        "Origin: Lateral supracondylar ridge of the humerus\n" +
        "Insertion: Styloid process of the radius";

    break;

            case "Flexor Carpi Radialis":
                forearmMuscleTitle.text = "Flexor Carpi Radialis";
                forearmDescriptionText.text = "This muscle bends the wrist and moves the hand toward the thumb side.";
                forearmFunctionText.text = "• Flexes the wrist\n• Abducts the hand";
                forearmLocationText.text = "Anterior Forearm";
                break;

            case "Palmaris Longus":
                forearmMuscleTitle.text = "Palmaris Longus";
                forearmDescriptionText.text = "The palmaris longus assists wrist flexion and tightens the palm. It is absent in some individuals.";
                forearmFunctionText.text = "• Flexes the wrist\n• Tightens the palmar fascia";
                forearmLocationText.text = "Anterior Forearm";
                break;

            case "Flexor Carpi Ulnaris":
                forearmMuscleTitle.text = "Flexor Carpi Ulnaris";
                forearmDescriptionText.text = "The flexor carpi ulnaris bends the wrist and moves the hand toward the little finger.";
                forearmFunctionText.text = "• Flexes the wrist\n• Adducts the hand";
                forearmLocationText.text = "Medial Forearm";
                break;

           default:
    shoulderMuscleTitle.text = "Muscle Not Found";
    shoulderDescriptionText.text = "";
    shoulderFunctionText.text = "";
    shoulderLocationText.text = "";

    upperArmMuscleTitle.text = "";
    upperArmDescriptionText.text = "";
    upperArmFunctionText.text = "";
    upperArmLocationText.text = "";

    forearmMuscleTitle.text = "";
    forearmDescriptionText.text = "";
    forearmFunctionText.text = "";
    forearmLocationText.text = "";
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
    public void OpenARScene()
{
    SceneManager.LoadScene("ARScene");
}
}