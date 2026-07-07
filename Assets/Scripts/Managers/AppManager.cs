using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
    public static AppManager Instance;

    [Header("Current Selection")]
    public string SelectedMuscleGroup = "";
    public string SelectedMuscle = "";

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

    public void SelectMuscleGroup(string groupName)
    {
        SelectedMuscleGroup = groupName;
        SceneManager.LoadScene("TopicScene");
    }

    public void SelectMuscle(string muscleName)
    {
        SelectedMuscle = muscleName;
    }

    public void OpenLessonScene()
    {
        SceneManager.LoadScene("LessonScene");
    }

    public void OpenVRScene()
    {
        SceneManager.LoadScene("VRScene");
    }
}