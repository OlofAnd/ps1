using System.Collections;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TMP_Text dialogText; // Reference to the TextMeshPro UI element
    [TextArea(3, 10)]
    public string[] dialogParts; // Array of dialog strings
    public float letterPause = 0.05f; // Time between each letter
    public float partPause = 2.0f; // Time to wait before next part starts
    private SkyboxManager skyboxManager;
    private int skyboxChangeIndex = 1; // The index after which the skybox should change SKA VARA 12!!!

    private void Start()
    {
        Debug.Log(skyboxChangeIndex);

        skyboxManager = FindObjectOfType<SkyboxManager>();
        StartCoroutine(DisplayDialog());
    }

    private IEnumerator DisplayDialog()
    {
        for (int i = 0; i < dialogParts.Length; i++)
        {
            yield return StartCoroutine(TypeText(dialogParts[i]));
            yield return new WaitForSeconds(partPause);

            if (i == skyboxChangeIndex)
            {
                Debug.Log("Changing skybox..."); // Debug log added here
                yield return StartCoroutine(skyboxManager.ChangeSkyboxWithFade());
            }
        }
    }

    private IEnumerator TypeText(string text)
    {
        dialogText.text = ""; // Clear the text initially
        foreach (char letter in text.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
    }
}
