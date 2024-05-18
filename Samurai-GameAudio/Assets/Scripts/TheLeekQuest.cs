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

    public StudioEventEmitter PickupSoundEmitter;

    [Header("Items")]
    public GameObject leekToCollect;
    public GameObject leekToGive;

    [Header("Quest Start Sound")]
    public GameObject questStartSoundEmitter;

    [Header("Quest Completion Sound")]
    public GameObject questCompletionSoundEmitter;

    [Header("Backround Music")]
    public BackgroundMusicController backgroundMusicController;

    [Header("Error Sound")]
    public StudioEventEmitter ErrorSoundEmitter;
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
        LeekNotPicked();
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
                backgroundMusicController.ChangeMusic(1);
            }
        }
    }
    public void PlayQuestStartSound()
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

                     // Play the leek pickup sound
                     PlayLeekPickupSound();
                }
            }
        }
    }

    
    // Function to play the leek pickup sound
void PlayLeekPickupSound()
{
    // Check if the leek pickup sound emitter is assigned
    if (PickupSoundEmitter != null)
    {
        PickupSoundEmitter.Play();
    }
    else
    {
        Debug.LogWarning("Leek pickup sound emitter is not assigned.");
    }
}
    void LeekNotPicked()
    {
    if (doesPlayerHaveLeek == false && marketSellerTrigger.GetComponent<MarketSellerTrigger>().playerIsInMarketSellerTrigger == true)
        {
            pressToGiveUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Play error sound
                PlayErrorSound();
            }
        }
    }

    void PlayErrorSound()
    {
     if (ErrorSoundEmitter != null)
    {
        ErrorSoundEmitter.Play();
        //UIManager.DisplayErrorMessage("You need to bring the leek back!");
    }
    else
    {
        Debug.LogWarning("Error sound emitter is not assigned.");
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
                // Quest is completed
                Debug.Log("Quest Completed!"); // Debug statement for testing

                // Call a function to play the quest complete sound
                PlayQuestCompleteSound();
                backgroundMusicController.ChangeMusic(0);
            }
        }   
    }

    public void PlayQuestCompleteSound()
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