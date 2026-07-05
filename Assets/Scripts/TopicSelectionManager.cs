using UnityEngine;
using UnityEngine.SceneManagement;

public class TopicSelectionManager : MonoBehaviour
{
    // Stores the topic selected by the user
    public static string SelectedTopic = "";

    // Opens the TopicScene and remembers the topic
    public void OpenTopic(string topicName)
    {
        SelectedTopic = topicName;

        Debug.Log("Selected Topic: " + SelectedTopic);

        SceneManager.LoadScene("TopicScene");
    }
}