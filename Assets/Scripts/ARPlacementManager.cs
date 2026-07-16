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

   public bool spawned = false;

private GameObject currentMuscle;
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
            Debug.Log("Screen tapped");

Debug.Log("Plane detected!");
        if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;

            // Raise the body slightly above the plane
            Vector3 spawnPosition = pose.position + new Vector3(0f, 0.5f, 0f);

            // Spawn the model
            Debug.Log("Selected Muscle: " + AppManager.Instance.SelectedMuscle);
            GameObject selectedMuscle = muscleSpawner.GetSelectedMusclePrefab();
           Debug.Log("Selected Muscle: " + AppManager.Instance.SelectedMuscle);

if(selectedMuscle != null)
    Debug.Log("Prefab Found: " + selectedMuscle.name);
else
    Debug.Log("Prefab is NULL");

if (selectedMuscle == null)
{
    Debug.Log("No muscle prefab found!");
    return;
}

currentMuscle = Instantiate(selectedMuscle, spawnPosition, Quaternion.identity);
currentMuscle.AddComponent<ARObjectInteraction>();

            // Make the body face the user
            Vector3 cameraPosition = Camera.main.transform.position;

            Vector3 lookDirection = cameraPosition - currentMuscle.transform.position;
            lookDirection.y = 0;

            currentMuscle.transform.rotation = Quaternion.LookRotation(-lookDirection);

            // Adjust size
            currentMuscle.transform.localScale = Vector3.one * 0.15f;
            spawned = true;
        }
    }

    public void ResetPlacement()
{
    if (currentMuscle != null)
    {
        Destroy(currentMuscle);
    }

    currentMuscle = null;
    spawned = false;
}
}