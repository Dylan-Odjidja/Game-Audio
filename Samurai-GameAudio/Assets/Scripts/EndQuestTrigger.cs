using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndQuestTrigger : MonoBehaviour
{
    public bool playerInEndTrigger;
    public GameObject SwordQuestCompleteSoundEmitter;
    
    // Start is called before the first frame update
    void Start()
    {
        playerInEndTrigger = false;
    }

    void Update()
    {
        //Debug status of trigger
        //Debug.Log("EndTrigger Status ="+playerInEndTrigger);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player"){
            playerInEndTrigger = true;
        } 
    }

    void OnTriggerExit(Collider player) {
        if(player.gameObject.tag == "Player"){
            playerInEndTrigger = false;
        }
    }

    public void PlayQuestCompletionSound()
    {
        if (SwordQuestCompleteSoundEmitter != null)
        {
            // Get the FMODUnity.StudioEventEmitter component from the GameObject
            var emitter = SwordQuestCompleteSoundEmitter.GetComponent<FMODUnity.StudioEventEmitter>();

            // Check if the emitter component exists
            if (emitter != null)
            {
                // Play the FMOD sound event associated with the emitter component
                emitter.Play();
            }
            else
            {
                Debug.LogError("No FMODUnity.StudioEventEmitter component found on the SwordQuestCompleteSoundEmitter GameObject.");
            }
        }
        else
        {
            Debug.LogError("qSwordQuestCompleteSoundEmitter GameObject reference is not set.");
        }
 
    }
}