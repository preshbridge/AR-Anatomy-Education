using UnityEngine;
using UnityEngine.UI;

public class TopicSceneManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject shoulderPanel;
    public GameObject upperArmPanel;
    public GameObject forearmPanel;

    [Header("Start Learning Button")]
    public Button startLearningButton;

    private void Start()
    {
        startLearningButton.interactable = false;

        shoulderPanel.SetActive(false);
        upperArmPanel.SetActive(false);
        forearmPanel.SetActive(false);

        switch (AppManager.Instance.SelectedMuscleGroup)
        {
            case "Shoulder":
                shoulderPanel.SetActive(true);
                break;

            case "Upper Arm":
                upperArmPanel.SetActive(true);
                break;

            case "Forearm":
                forearmPanel.SetActive(true);
                break;
        }
    }

    public void SelectMuscle(string muscleName)
    {
        AppManager.Instance.SelectMuscle(muscleName);
        startLearningButton.interactable = true;

        Debug.Log("Selected Muscle: " + muscleName);
    }

    public void StartLearning()
    {
        AppManager.Instance.OpenLessonScene();
    }
}