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

    [Header("Background Music Control")]
    public BackgroundMusicController musicController; // Reference to BackgroundMusicController script

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

        //Find the BackgroundMusicController script in the scene
       // musicController = FindObjectOfType<BackgroundMusicController>();
        //if (musicController == null)
        //{
          //  Debug.LogError("BackgroundMusicController script not found in the scene.");
        //}
    }
    

    // Update is called once per frame
    void Update()
    {
        LeekPickup();
        MarketSellerStart();
        MarketSellerEnd();
       // CheckQuestCompletion();
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
              // musicController.SwitchToQuestMusic(); // Switch to quest music
               // StartQuest();
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
       //musicController.SwitchToDefaultMusic(); // Switch back to default music
      // EndQuest();
            }

        
        }
            
        }

            // Method to start the quest
    void StartQuest()
    {
        questStarted = true;
        // Switch background music to quest mode
        musicController.SwitchToQuestMusic();
        // Other quest start actions...
    }

    // Method to end the quest
    void EndQuest()
    {
        questStarted = false;
        // Switch background music to default mode
        musicController.SwitchToDefaultMusic();
        // Other quest end actions...
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
