using UnityEngine;
using UnityEngine.UI;

public class TopicSceneManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject shoulderPanel;
    public GameObject upperArmPanel;
    public GameObject forearmPanel;

    [Header("Start Learning")]
    public Button startLearningButton;

   private void Start()
{
    Debug.Log("Topic received: " + TopicSelectionManager.SelectedTopic);

    startLearningButton.interactable = false;

    shoulderPanel.SetActive(false);
    upperArmPanel.SetActive(false);
    forearmPanel.SetActive(false);

    switch (TopicSelectionManager.SelectedTopic)
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

        default:
            shoulderPanel.SetActive(true);
            break;
    }
}
}