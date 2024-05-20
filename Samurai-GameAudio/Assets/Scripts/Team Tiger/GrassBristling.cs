using UnityEngine;
using FMODUnity;

public class GrassBristling : MonoBehaviour
{
    public StudioEventEmitter grassBristlingEmitter;
    public ThirdPersonUserControl thirdPersonUserControl;

    private void Start()
    {
        thirdPersonUserControl = GetComponent<ThirdPersonUserControl>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayGrassBristlingSound();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopGrassBristlingSound();
        }
    }

    public void PlayGrassBristlingSound()
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

    public void StopGrassBristlingSound()
    {
        // Check if the grass bristling emitter is assigned and playing
        if (grassBristlingEmitter != null && grassBristlingEmitter.IsPlaying())
        {
            // Stop the grass bristling sound
            grassBristlingEmitter.Stop();
        }
    }
}