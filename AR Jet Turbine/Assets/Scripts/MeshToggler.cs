using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshToggler : MonoBehaviour
{

    [SerializeField] private GameObject TurbineObject;
    private bool isActive = true;

    public void Toggle()
    {

        isActive = !isActive;
        TurbineObject.SetActive(isActive);
    }
}
