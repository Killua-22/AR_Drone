using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARplacement : MonoBehaviour
{

    public GameObject arObjecttoSpawn;
    public GameObject placementIndicator;
    private GameObject _spawnedObject;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseisvalid = false;


    // Start is called before the first frame update
    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_spawnedObject == null && placementPoseisvalid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject();
        }

        UpdatePlacementPose();
        UpdatePlacementIndicator();

    }

    void UpdatePlacementIndicator()
    {
        if (_spawnedObject == null && placementPoseisvalid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseisvalid = hits.Count > 0;
        if (placementPoseisvalid)
        {
            PlacementPose = hits[0].pose;
        }
    }

    void ARPlaceObject()
    {
        arObjecttoSpawn.SetActive(true);
        arObjecttoSpawn.transform.SetLocalPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        _spawnedObject = arObjecttoSpawn;
    }

    
}