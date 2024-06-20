using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Random = UnityEngine.Random;

public class PlanePlacementManager : MonoBehaviour
{
    [SerializeField] private GameObject[] flowers;

    [SerializeField] private XROrigin xrOrigin;
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private ARPlaneManager planeManager;


    private GameObject _instantiatedObject = null;
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Shoot Raycast
            // Place The Objects Randomly
            // Disable The Planes and The Plane Manager

            bool collision = raycastManager.Raycast(Input.GetTouch(0).position, raycastHits, TrackableType.PlaneWithinPolygon);

            if (collision && _instantiatedObject == null)
            {
                _instantiatedObject = Instantiate(flowers[Random.Range(0, flowers.Length - 1)],
                    raycastHits[0].pose.position, raycastHits[0].pose.rotation);

                foreach (var plane in planeManager.trackables)
                {
                    plane.gameObject.SetActive(false);
                }

                planeManager.enabled = false;

                // GameObject _object = Instantiate(flowers[Random.Range(0, flowers.Length - 1)]);
                // _object.transform.position = raycastHits[0].pose.position;
            }

            // foreach (var plane in planeManager.trackables)
            // {
            //     plane.gameObject.SetActive(false);
            // }
            //
            // planeManager.enabled = false;
        }
    }
}
