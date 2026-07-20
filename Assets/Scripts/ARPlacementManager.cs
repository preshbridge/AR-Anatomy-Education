using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacementManager : MonoBehaviour
{
    [Header("References")]
    public MuscleSpawner muscleSpawner;

    [SerializeField]
    private ARRaycastManager raycastManager;

    private GameObject currentMuscle;

    private bool spawned = false;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        // Don't allow another muscle while one already exists
        if (spawned)
            return;

        // Wait for touch
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began)
            return;

        Debug.Log("Screen Tapped");

        // Check if a plane was touched
        if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            Debug.Log("Plane Detected");

            Pose pose = hits[0].pose;

            // Raise the model slightly above the plane
            Vector3 spawnPosition = pose.position + Vector3.up * 0.5f;

            GameObject selectedMuscle = muscleSpawner.GetSelectedMusclePrefab();

            if (selectedMuscle == null)
            {
                Debug.LogError("No muscle prefab selected!");
                return;
            }

            Debug.Log("Spawning: " + selectedMuscle.name);

            // Spawn muscle
            currentMuscle = Instantiate(selectedMuscle, spawnPosition, Quaternion.identity);

            // Add interaction script only if it doesn't already exist
            if (currentMuscle.GetComponent<ARObjectInteraction>() == null)
            {
                currentMuscle.AddComponent<ARObjectInteraction>();
            }

            // Face the camera
            Vector3 lookDirection = Camera.main.transform.position - currentMuscle.transform.position;
            lookDirection.y = 0;

            if (lookDirection != Vector3.zero)
            {
                currentMuscle.transform.rotation = Quaternion.LookRotation(-lookDirection);
            }

            // Scale the muscle
            currentMuscle.transform.localScale = Vector3.one * 0.25f;

            spawned = true;
        }
    }

    public void ResetPlacement()
    {
        if (currentMuscle != null)
        {
            Destroy(currentMuscle);
            currentMuscle = null;
        }

        spawned = false;

        Debug.Log("Muscle Reset. Tap a plane to place another muscle.");
    }
}