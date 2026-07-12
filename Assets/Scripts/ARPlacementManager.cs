using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacementManager : MonoBehaviour
{
    public GameObject humanBodyPrefab;

   [SerializeField]
private ARRaycastManager raycastManager;
    private bool spawned = false;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        
    }

    void Update()
    {
        if (spawned)
            return;

        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began)
            return;

        if (raycastManager.Raycast(touch.position, hits, TrackableType.Planes))
        {
            Pose pose = hits[0].pose;

            Instantiate(humanBodyPrefab, pose.position, pose.rotation);

            spawned = true;
        }
    }
}