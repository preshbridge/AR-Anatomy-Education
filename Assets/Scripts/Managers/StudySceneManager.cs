using UnityEngine;

public class StudySceneManager : MonoBehaviour
{
    public void OpenShoulder()
    {
        Debug.Log("Opening Shoulder");
        AppManager.Instance.SelectMuscleGroup("Shoulder");
    }

    public void OpenUpperArm()
    {
        Debug.Log("Opening Upper Arm");
        AppManager.Instance.SelectMuscleGroup("Upper Arm");
    }

    public void OpenForearm()
    {
        Debug.Log("Opening Forearm");
        AppManager.Instance.SelectMuscleGroup("Forearm");
    }
}