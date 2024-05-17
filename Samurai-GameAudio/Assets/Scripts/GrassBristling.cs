using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


public class GrassBristling : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter grassBristlingEmitter;
    public ThirdPersonUserControl thirdPersonUserControl;
    public ThirdPersonCharacter Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayGrassBristlingSound();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopGrassBristlingSound();
        }
    }

    private void PlayGrassBristlingSound()
    {
        // Check if the grass bristling emitter is assigned
        if (grassBristlingEmitter != null)
        {
            // Get the player's current walk type (walking, running, crouching)
            int walkType = thirdPersonUserControl.playerWalkType;

            // Set the appropriate parameter in FMOD
            grassBristlingEmitter.SetParameter("Sound Level", walkType);

            // Play the grass bristling sound
            grassBristlingEmitter.Play();
        }
        else
        {
            Debug.LogError("Grass bristling emitter is not assigned.");
        }
    }

    private void StopGrassBristlingSound()
    {
        // Check if the grass bristling emitter is assigned and playing
        if (grassBristlingEmitter != null && grassBristlingEmitter.IsPlaying())
        {
            // Stop the grass bristling sound
            grassBristlingEmitter.Stop();
        }
    }
}