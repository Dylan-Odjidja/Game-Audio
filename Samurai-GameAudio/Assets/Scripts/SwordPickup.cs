using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{ 
    public bool playerCanPickupSword;
    public GameObject SwordquestStartSoundEmitter;
    
    void Awake()
    {
        playerCanPickupSword = false;
    }

    void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player"){
            playerCanPickupSword = true;
        }
    }
    
    public void PlaySwordQuestStartSound()
{
    // Check if the Sword quest start sound emitter is assigned
    if (SwordquestStartSoundEmitter != null)
    {
        // Get the FMODUnity.StudioEventEmitter component
        var soundEmitter = SwordquestStartSoundEmitter.GetComponent<FMODUnity.StudioEventEmitter>();
        if (soundEmitter != null)
        {
            // Play the sound
            soundEmitter.Play();
        }
        else
        {
            Debug.LogError("Sword Quest start sound emitter is missing FMODUnity.StudioEventEmitter component.");
        }
    }
    else
    {
        Debug.LogError("Sword Quest start sound emitter is not assigned.");
    }
}


    void OnTriggerExit(Collider player)
    {
        if(player.gameObject.tag == "Player"){
            playerCanPickupSword = false;
        }
    }
}
