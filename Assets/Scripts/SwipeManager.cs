using UnityEngine;
using TMPro;

public class SwipeManager : MonoBehaviour
{
    [Header("Cards")]
    public GameObject[] cards;

    [Header("Indicators")]
    public TMP_Text[] dots;

    [Header("Swipe Settings")]
    public float swipeThreshold = 50f;

    private int currentCard = 0;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private void Start()
    {
        if (cards == null || cards.Length == 0)
        {
            Debug.LogError("No cards assigned to SwipeManager.");
            return;
        }

        ShowCard(currentCard);
    }

    private void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE

        // Mouse swipe (Unity Editor)
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            endTouchPosition = Input.mousePosition;
            DetectSwipe();
        }

#else

        // Finger swipe (Android)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                startTouchPosition = touch.position;

            if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                DetectSwipe();
            }
        }

#endif
    }

    private void DetectSwipe()
    {
        float swipeDistance = endTouchPosition.x - startTouchPosition.x;

        if (Mathf.Abs(swipeDistance) < swipeThreshold)
            return;

        if (swipeDistance < 0)
            NextCard();
        else
            PreviousCard();
    }

    private void NextCard()
    {
        if (currentCard < cards.Length - 1)
        {
            currentCard++;
            ShowCard(currentCard);
        }
    }

    private void PreviousCard()
    {
        if (currentCard > 0)
        {
            currentCard--;
            ShowCard(currentCard);
        }
    }

    private void ShowCard(int index)
    {
        // Show only the current card
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i] != null)
                cards[i].SetActive(i == index);
        }

        // Update dots
        if (dots != null && dots.Length > 0)
        {
            for (int i = 0; i < dots.Length; i++)
            {
                if (dots[i] == null)
                    continue;

                dots[i].color = (i == index) ? Color.white : Color.gray;
                dots[i].fontSize = (i == index) ? 42 : 34;
            }
        }
    }
}