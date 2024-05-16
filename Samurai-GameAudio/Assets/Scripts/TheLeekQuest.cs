using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class TheLeekQuest : MonoBehaviour
{
    [Header("Triggers")]
    public GameObject leekTrigger;
    public GameObject marketSellerTrigger;

    [Header("UI Elements")]
    public GameObject pressToTalkUI;
    public GameObject pressToPickUpUI;
    public GameObject pressToGiveUI;
    public GameObject leekUIImage;
    [Header("Items")]
    public GameObject leekToCollect;
    public GameObject leekToGive;

    [Header("Quest Start Sound")]
    public GameObject questStartSoundEmitter;

    [Header("Quest Completion Sound")]
    public GameObject questCompletionSoundEmitter;

    public bool questStarted;
    bool doesPlayerHaveLeek;
    // Start is called before the first frame update
    void Start()
    {
        questStarted = false;
        pressToGiveUI.SetActive(false);
        pressToPickUpUI.SetActive(false);
        pressToTalkUI.SetActive(false);
        leekToGive.SetActive(false);
        leekUIImage.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        LeekPickup();
        MarketSellerStart();
        MarketSellerEnd();
   
    }

    void MarketSellerStart()
    {
        if (marketSellerTrigger.GetComponent<MarketSellerTrigger>().playerIsInMarketSellerTrigger == true && questStarted == false)
        {
            pressToTalkUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Add your conversation here

                questStarted = true;
                pressToTalkUI.SetActive(false);
                 // Call function to play the quest start sound
                PlayQuestStartSound();
              
        }
            }
        }

   
    void PlayQuestStartSound()
{
    // Check if the quest start sound emitter is assigned
    if (questStartSoundEmitter != null)
    {
        // Get the FMODUnity.StudioEventEmitter component
        var soundEmitter = questStartSoundEmitter.GetComponent<FMODUnity.StudioEventEmitter>();
        if (soundEmitter != null)
        {
            // Play the sound
            soundEmitter.Play();
        }
        else
        {
            Debug.LogError("Quest start sound emitter is missing FMODUnity.StudioEventEmitter component.");
        }
    }
    else
    {
        Debug.LogError("Quest start sound emitter is not assigned.");
    }
}
    

    void LeekPickup()
    {
        if (questStarted == true && leekTrigger.GetComponent<LeekPickup>().playerIsInLeekTrigger == true)
        {
            if (doesPlayerHaveLeek == false)
            {
                pressToPickUpUI.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pressToPickUpUI.SetActive(false);
                    Destroy(leekToCollect);
                    doesPlayerHaveLeek = true;
                    leekUIImage.SetActive(true);


                }
            }
        }
    }


    void MarketSellerEnd()
    {
        if (doesPlayerHaveLeek == true && marketSellerTrigger.GetComponent<MarketSellerTrigger>().playerIsInMarketSellerTrigger == true)
        {
            pressToGiveUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                doesPlayerHaveLeek = false;
                pressToGiveUI.SetActive(false);
                leekToGive.SetActive(true);
                leekUIImage.SetActive(false);
            }
        if (doesPlayerHaveLeek && marketSellerTrigger.GetComponent<MarketSellerTrigger>().playerIsInMarketSellerTrigger)
        {
        // Quest is completed
        Debug.Log("Quest Completed!"); // Debug statement for testing

        // Call a function to play the quest complete sound
        PlayQuestCompleteSound();
       
            }

        
        }
            
    }


        

     void PlayQuestCompleteSound()
    {
        if (questCompletionSoundEmitter != null)
        {
            var soundEmitter = questCompletionSoundEmitter.GetComponent<FMODUnity.StudioEventEmitter>();
            if (soundEmitter != null)
            {
                soundEmitter.Play();
            }
            else
            {
                Debug.LogError("Quest completion sound emitter is missing FMODUnity.StudioEventEmitter component.");
            }
        }
        else
        {
            Debug.LogError("Quest completion sound emitter is not assigned.");
        }
    
    }

}
