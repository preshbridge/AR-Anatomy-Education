using UnityEngine;

public class ARMuscleManager : MonoBehaviour
{
    [Header("Shoulder")]
    public GameObject deltoid;
    public GameObject supraspinatus;
    public GameObject infraspinatus;
    public GameObject teresMinor;
    public GameObject subscapularis;

    [Header("Upper Arm")]
    public GameObject bicepsBrachii;
    public GameObject tricepsBrachii;
    public GameObject brachialis;
    public GameObject coracobrachialis;

    [Header("Forearm")]
    public GameObject brachioradialis;
    public GameObject flexorCarpiRadialis;
    public GameObject palmarisLongus;
    public GameObject flexorCarpiUlnaris;

    void Start()
    {
        HideAllMuscles();

        switch (AppManager.Instance.SelectedMuscle)
        {
            case "Deltoid":
                deltoid.SetActive(true);
                break;

            case "Supraspinatus":
                supraspinatus.SetActive(true);
                break;

            case "Infraspinatus":
                infraspinatus.SetActive(true);
                break;

            case "Teres Minor":
                teresMinor.SetActive(true);
                break;

            case "Subscapularis":
                subscapularis.SetActive(true);
                break;

            case "Biceps Brachii":
                bicepsBrachii.SetActive(true);
                break;

            case "Triceps Brachii":
                tricepsBrachii.SetActive(true);
                break;

            case "Brachialis":
                brachialis.SetActive(true);
                break;

            case "Coracobrachialis":
                coracobrachialis.SetActive(true);
                break;

            case "Brachioradialis":
                brachioradialis.SetActive(true);
                break;

            case "Flexor Carpi Radialis":
                flexorCarpiRadialis.SetActive(true);
                break;

            case "Palmaris Longus":
                palmarisLongus.SetActive(true);
                break;

            case "Flexor Carpi Ulnaris":
                flexorCarpiUlnaris.SetActive(true);
                break;
        }
    }

    void HideAllMuscles()
    {
        deltoid.SetActive(false);
        supraspinatus.SetActive(false);
        infraspinatus.SetActive(false);
        teresMinor.SetActive(false);
        subscapularis.SetActive(false);

        bicepsBrachii.SetActive(false);
        tricepsBrachii.SetActive(false);
        brachialis.SetActive(false);
        coracobrachialis.SetActive(false);

        brachioradialis.SetActive(false);
        flexorCarpiRadialis.SetActive(false);
        palmarisLongus.SetActive(false);
        flexorCarpiUlnaris.SetActive(false);
    }
}