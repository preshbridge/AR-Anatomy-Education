using UnityEngine;

public class ARObjectInteraction : MonoBehaviour
{
    private float rotationSpeed = 0.2f;
    private float zoomSpeed = 0.005f;

    void Update()
    {
        RotateObject();
        ZoomObject();
    }

    void RotateObject()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.Rotate(0,
                    -touch.deltaPosition.x * rotationSpeed,
                    0,
                    Space.World);
            }
        }
    }

    void ZoomObject()
    {
        if (Input.touchCount == 2)
        {
            Touch finger1 = Input.GetTouch(0);
            Touch finger2 = Input.GetTouch(1);

            Vector2 finger1PrevPos = finger1.position - finger1.deltaPosition;
            Vector2 finger2PrevPos = finger2.position - finger2.deltaPosition;

            float prevDistance = (finger1PrevPos - finger2PrevPos).magnitude;
            float currentDistance = (finger1.position - finger2.position).magnitude;

            float difference = currentDistance - prevDistance;

            transform.localScale += Vector3.one * difference * zoomSpeed;

            float minScale = 0.05f;
            float maxScale = 10f;

            transform.localScale = new Vector3(
                Mathf.Clamp(transform.localScale.x, minScale, maxScale),
                Mathf.Clamp(transform.localScale.y, minScale, maxScale),
                Mathf.Clamp(transform.localScale.z, minScale, maxScale)
            );
        }
    }
}