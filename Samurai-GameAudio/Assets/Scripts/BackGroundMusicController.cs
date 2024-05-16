using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;


public class BackgroundMusicController : MonoBehaviour
{
 // Reference to the FMOD event instance representing the music
    public EventInstance musicEventInstance;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the music event instance
        musicEventInstance = FMODUnity.RuntimeManager.CreateInstance("eevent:/Music/BackgroundMusic");

        // Start playing the music
        musicEventInstance.start();
    }

    // Function to switch to quest music
    public void SwitchToQuestMusic()
    {
        // Set the value of the "GameMode" global parameter to "Quest"
        musicEventInstance.setParameterByName("InQuest", 1); // Assuming 1 represents "Quest"
         musicEventInstance.setParameterByName("NoQuest", 0);
    }

    // Function to switch to default music
    public void SwitchToDefaultMusic()
    {
        // Set the value of the "GameMode" global parameter to "Default"
        musicEventInstance.setParameterByName("InQuest", 0); // Assuming 0 represents "Default"
        musicEventInstance.setParameterByName("NoQuest", 1);
    }
}
