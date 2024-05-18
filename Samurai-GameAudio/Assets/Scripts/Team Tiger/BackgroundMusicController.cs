using FMODUnity;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    public StudioEventEmitter musicEventEmitter;

    public void ChangeMusic(int questStatus)
    {
        musicEventEmitter.SetParameter("QUEST", questStatus);
    }
}