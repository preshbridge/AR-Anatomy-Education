using UnityEngine;

public class MuscleSpawner : MonoBehaviour
{
    [Header("Muscle Prefabs")]
    public GameObject deltoidPrefab;
    public GameObject supraspinatusPrefab;
    public GameObject infraspinatusPrefab;
    public GameObject teresMinorPrefab;
    public GameObject subscapularisPrefab;

    public GameObject bicepsBrachiiPrefab;
    public GameObject brachialisPrefab;
    public GameObject coracobrachialisPrefab;
    public GameObject tricepsBrachiiPrefab;

    public GameObject brachioradialisPrefab;
    public GameObject flexorCarpiRadialisPrefab;
    public GameObject palmarisLongusPrefab;
    public GameObject flexorCarpiUlnarisPrefab;

    public GameObject GetSelectedMusclePrefab()
    {
        switch (AppManager.Instance.SelectedMuscle)
        {
            case "Deltoid":
                return deltoidPrefab;

            case "Supraspinatus":
                return supraspinatusPrefab;

            case "Infraspinatus":
                return infraspinatusPrefab;

            case "Teres Minor":
                return teresMinorPrefab;

            case "Subscapularis":
                return subscapularisPrefab;

            case "Biceps Brachii":
                return bicepsBrachiiPrefab;

            case "Brachialis":
                return brachialisPrefab;

            case "Coracobrachialis":
                return coracobrachialisPrefab;

            case "Triceps Brachii":
                return tricepsBrachiiPrefab;

            case "Brachioradialis":
                return brachioradialisPrefab;

            case "Flexor Carpi Radialis":
                return flexorCarpiRadialisPrefab;

            case "Palmaris Longus":
                return palmarisLongusPrefab;

            case "Flexor Carpi Ulnaris":
                return flexorCarpiUlnarisPrefab;

            default:
                return null;
        }
    }
}