using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepScript : MonoBehaviour
{
    public GameObject footstep;
    public float footstepCooldown = 0.5f; // Cooldown duration in seconds
    private bool canPlayFootstep = true; // To check if footstep sound can be played

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") && canPlayFootstep)
        {
            StartCoroutine(FootstepRoutine());
        }

        if (Input.GetKeyDown("s") && canPlayFootstep)
        {
            StartCoroutine(FootstepRoutine());
        }

        if (Input.GetKeyUp("w"))
        {
            StopFootsteps();
        }

        if (Input.GetKeyUp("s"))
        {
            StopFootsteps();
        }
    }

    IEnumerator FootstepRoutine()
    {
        canPlayFootstep = false; // Prevent further footstep sounds
        footsteps();
        yield return new WaitForSeconds(footstepCooldown);
        canPlayFootstep = true; // Allow footstep sounds again after cooldown
    }

    void footsteps()
    {
        footstep.SetActive(true);
        // Play footstep sound here if needed
    }

    void StopFootsteps()
    {
        footstep.SetActive(false);
    }
}
