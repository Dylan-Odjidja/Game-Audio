using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;


public class BackgroundMusicController : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter musicEmitter;
    public GameObject CameraObject;
    void Start()
    {
        // Find the FMOD Studio Event Emitter component attached to the camera
        musicEmitter = CameraObject.GetComponent<FMODUnity.StudioEventEmitter>();
        if (musicEmitter == null)
        {
            Debug.LogError("FMOD Studio Event Emitter not found on the camera.");
        }
    }

    public void SwitchToQuestMusic()
    {
        if (musicEmitter != null)
        {
            // Set FMOD parameter to play quest music
            musicEmitter.SetParameter("InQuest", 1);
            musicEmitter.SetParameter("NoQuest", 0);
        }
    }

    public void SwitchToDefaultMusic()
    {
        if (musicEmitter != null)
        {
            // Set FMOD parameter to play default music
            musicEmitter.SetParameter("InQuest", 0);
            musicEmitter.SetParameter("NoQuest", 1);
        }
    }
}

