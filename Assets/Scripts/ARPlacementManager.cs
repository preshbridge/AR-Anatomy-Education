using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacementManager : MonoBehaviour
{
    [Header("Human Body Prefab")]
    public MuscleSpawner muscleSpawner;
    [SerializeField]
    private ARRaycastManager raycastManager;

    private bool spawned = false;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (spawned)
            return;

        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began)
            return;

        if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;

            // Raise the body slightly above the plane
            Vector3 spawnPosition = pose.position + new Vector3(0f, 0.15f, 0f);

            // Spawn the model
            GameObject selectedMuscle = muscleSpawner.GetSelectedMusclePrefab();

if (selectedMuscle == null)
{
    Debug.Log("No muscle prefab found!");
    return;
}

GameObject body = Instantiate(selectedMuscle, pose.position, Quaternion.identity);

            // Make the body face the user
            Vector3 cameraPosition = Camera.main.transform.position;

            Vector3 lookDirection = cameraPosition - body.transform.position;
            lookDirection.y = 0;

            body.transform.rotation = Quaternion.LookRotation(-lookDirection);

            // Adjust size
            body.transform.localScale = Vector3.one * 0.005f;

            spawned = true;
        }
    }
}