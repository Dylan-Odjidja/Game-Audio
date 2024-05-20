using UnityEngine;

public class GrassBristleTrigger : MonoBehaviour
{
    public GrassBristling grassBristling;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        grassBristling = player.GetComponent<GrassBristling>();
    }

    // public ThirdPersonCharacter Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            grassBristling.PlayGrassBristlingSound();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            grassBristling.StopGrassBristlingSound();
        }
    }
}