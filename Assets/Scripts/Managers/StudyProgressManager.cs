using UnityEngine;
using TMPro;

public class StudyProgressManager : MonoBehaviour
{
    public TMP_Text shoulderProgress;
    public TMP_Text upperArmProgress;
    public TMP_Text forearmProgress;

    void Start()
    {
        LoadProgress();
    }

    void LoadProgress()
    {
        shoulderProgress.text =
            PlayerPrefs.GetFloat("ShoulderProgress", 0).ToString("F0") + "%";

        upperArmProgress.text =
            PlayerPrefs.GetFloat("UpperArmProgress", 0).ToString("F0") + "%";

        forearmProgress.text =
            PlayerPrefs.GetFloat("ForearmProgress", 0).ToString("F0") + "%";
    }
}