using UnityEngine;

public class StudySceneManager : MonoBehaviour
{
    public void OpenShoulder()
    {
        AppManager.Instance.SelectMuscleGroup("Shoulder");
    }

    public void OpenUpperArm()
    {
        AppManager.Instance.SelectMuscleGroup("Upper Arm");
    }

    public void OpenForearm()
    {
        AppManager.Instance.SelectMuscleGroup("Forearm");
    }
}