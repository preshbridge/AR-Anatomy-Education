using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopicSceneManager : MonoBehaviour
{
    [Header("Muscle Cards")]
    public Button[] muscleCards;

    [Header("Start Learning Button")]
    public Button startLearningButton;

    private int selectedCard = -1;

    private void Start()
    {
        // Disable Start Learning
        startLearningButton.interactable = false;

        // Add click listeners to every muscle card
        for (int i = 0; i < muscleCards.Length; i++)
        {
            int index = i;
            muscleCards[i].onClick.AddListener(() => SelectCard(index));
        }
    }

    void SelectCard(int index)
    {
        selectedCard = index;

        // Enable Start Learning
        startLearningButton.interactable = true;

        // Highlight selected card
        for (int i = 0; i < muscleCards.Length; i++)
        {
            ColorBlock colors = muscleCards[i].colors;

            if (i == index)
            {
                colors.normalColor = new Color(0.75f, 1f, 0.75f); // Light green
            }
            else
            {
                colors.normalColor = Color.white;
            }

            muscleCards[i].colors = colors;
        }
    }
}