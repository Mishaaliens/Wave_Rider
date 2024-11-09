using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public Vector3 rotationAxis = new Vector3(0, 1, 0); // Axis to rotate around (e.g., Y-axis by default)
    public float rotationSpeed = 30f; // Speed of rotation in degrees per second

    void Update()
    {
        // Calculate the rotation amount
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Rotate the object around the specified axis
        transform.Rotate(rotationAxis, rotationAmount, Space.Self);
    }
}

