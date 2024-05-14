using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    // Define the FMOD parameter names
    public string inQuestParameterName = "InQuest";
    public string noQuestParameterName = "NoQuest";

    // Flag to track if the player is in quest mode
    private bool inQuestMode = false;

    public KeyCode triggerEvent = KeyCode.E; // Specify the trigger event in the Inspector

    void Update()
    {
        // Check for player interaction (e.g., pressing triggerEvent)
        if (Input.GetKeyDown(triggerEvent))
        {
            // Toggle between default and quest modes
            ToggleMusicMode();
        }
    }

    // Method to toggle between default and quest modes
    void ToggleMusicMode()
    {
        // Toggle the quest mode
        inQuestMode = !inQuestMode;

        // Trigger the appropriate music parameter based on the mode
        if (inQuestMode)
        {
            // Set quest music parameter
            SetMusicParameter(inQuestParameterName);
        }
        else
        {
            // Set default music parameter
            SetMusicParameter(noQuestParameterName);
        }
    }

    // Method to set the music parameter directly
    void SetMusicParameter(string paramName)
    {
        // Set the FMOD parameter directly
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName(paramName, 1); // Or whatever value you want to set
    }
}

