using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class FurniturePlacement : MonoBehaviour
{
    public GameObject SpawnableFurniture;
    [SerializeField] private XROrigin xrOrigin;
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private ARPlaneManager planeManager;


    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            bool collision = raycastManager.Raycast(Input.GetTouch(0).position, raycastHits,
                UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);

            if (collision && isButtonPressed() == false)
            {
                GameObject _object = Instantiate(SpawnableFurniture, raycastHits[0].pose.position,
                    raycastHits[0].pose.rotation);

                foreach (var planes in planeManager.trackables)
                {
                    planes.gameObject.SetActive(false);
                }

                planeManager.enabled = false;
            }
        }
    }

    public bool isButtonPressed()
    {
        if (EventSystem.current.currentSelectedGameObject?.GetComponent<Button>() == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void SwitchFurniture(GameObject furniture)
    {
        SpawnableFurniture = furniture;
    }


}
