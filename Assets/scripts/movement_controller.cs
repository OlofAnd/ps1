using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_controller : MonoBehaviour
{
    public float movementSpeed = 5f; // Speed of player movement


    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        // Get input from W and S keys
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate movement amount based on input and speed
        float movementAmount = verticalInput * movementSpeed * Time.deltaTime;

        // Move the player forwards/backwards along its own z-axis
        transform.Translate(Vector3.forward * movementAmount);
    }
}
