using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] private Vector3 rotationVector;

    private void Update()
    {
        transform.Rotate(rotationVector * Time.deltaTime);
    }
}
