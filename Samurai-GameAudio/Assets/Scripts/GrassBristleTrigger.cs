using UnityEngine;

public class GrassBristleTrigger : MonoBehaviour
{
    public GrassBristling grassBristling; // Reference to the GrassBristling script
   // public ThirdPersonCharacter Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Call a method in the GrassBristling script to handle the trigger enter event
            grassBristling.PlayGrassBristlingSound();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Call a method in the GrassBristling script to handle the trigger exit event
            grassBristling.StopGrassBristlingSound();
        }
    }
}
