using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    public Material newSkybox;
    public Material originalSkybox;
    public FadeManager fadeManager;

    private void Start()
    {
        Debug.Log("helloe");
        fadeManager = FindObjectOfType<FadeManager>();
        originalSkybox = RenderSettings.skybox;
    }

    public IEnumerator ChangeSkyboxWithFade()
    {
        Debug.Log("Changing Skybox...");

        yield return fadeManager.FadeOut();

        RenderSettings.skybox = newSkybox;
        DynamicGI.UpdateEnvironment(); // Update the lighting for the new skybox

        yield return new WaitForSeconds(1.0f); // Optional wait time while the screen is black

        yield return fadeManager.FadeIn();
    }

    public void ResetSkybox()
    {
        RenderSettings.skybox = originalSkybox;
        DynamicGI.UpdateEnvironment();
    }
}
