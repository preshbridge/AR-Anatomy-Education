using UnityEngine;
using UnityEngine.SceneManagement;

public class TopicSelectionManager : MonoBehaviour
{
    // Stores the topic the user selected
    public static string SelectedTopic;

    // Called when Shoulder is selected
    public void SelectShoulder()
    {
        SelectedTopic = "Shoulder";
        SceneManager.LoadScene("TopicScene");
    }

    // Called when Upper Arm is selected
    public void SelectUpperArm()
    {
        SelectedTopic = "Upper Arm";
        SceneManager.LoadScene("TopicScene");
    }

    // Called when Forearm is selected
    public void SelectForearm()
    {
        SelectedTopic = "Forearm";
        SceneManager.LoadScene("TopicScene");
    }
}