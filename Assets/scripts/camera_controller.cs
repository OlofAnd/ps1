using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    public float rotationSpeed = 5f; // Speed of camera rotation

    // Reference to the main camera
    private Transform mainCameraTransform;

    void Start()
    {
        // Get reference to the main camera's transform
        mainCameraTransform = transform.GetChild(0); // Assuming the main camera is the first child
    }

    void Update()
    {
        // Check if the main camera transform is initialized
        if (mainCameraTransform == null)
        {
            Debug.LogError("Main camera transform is not set!");
            return;
        }

        // Get input from A and D keys
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Calculate rotation amount based on input and speed
        float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;

        // Apply rotation to the camera around the Y-axis (up direction)
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
