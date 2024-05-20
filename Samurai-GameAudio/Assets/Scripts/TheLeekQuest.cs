using FMODUnity;
using System.Collections;
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

    [Header("Quest Sounds")]
    public GameObject questStartSoundEmitter;
    public GameObject questEndSoundEmitter;
    public GameObject leekGrabSoundEmitter;

    [Header("Backround Music")]
    public BackgroundMusicController backgroundMusicController;

    internal bool questStarted;
    internal bool questCompleted;
    internal bool doesPlayerHaveLeek;

    void Start()
    {
        questStarted = false;
        pressToGiveUI.SetActive(false);
        pressToPickUpUI.SetActive(false);
        pressToTalkUI.SetActive(false);
        leekToGive.SetActive(false);
        leekUIImage.SetActive(false);
    }

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
                pressToTalkUI.SetActive(false);
                StartCoroutine(ErrorTimeout());
                PlayQuestStartSound();
                backgroundMusicController.ChangeMusic(1);
            }
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
                    PlayLeekGrabSound();
                }
            }
        }
    }

    void MarketSellerEnd()
    {
        if (marketSellerTrigger.GetComponent<MarketSellerTrigger>().playerIsInMarketSellerTrigger == true && questStarted == true && !questCompleted)
        {
            pressToGiveUI.SetActive(true);
            pressToTalkUI.SetActive(false);
            if (Input.GetKeyDown(KeyCode.E) && doesPlayerHaveLeek == true)
            {
                doesPlayerHaveLeek = false;
                pressToGiveUI.SetActive(false);
                leekToGive.SetActive(true);
                leekUIImage.SetActive(false);
                questCompleted = true;
                PlayQuestCompleteSound();
            }
            else if (Input.GetKeyDown(KeyCode.E) && (doesPlayerHaveLeek == false)) 
            {
                RuntimeManager.PlayOneShot("event:/Interactable/Quest Error", this.transform.position);
            }
        }
    }

    public void PlayQuestStartSound()
    {
        if (questStartSoundEmitter != null)
        {
            var soundEmitter = questStartSoundEmitter.GetComponent<StudioEventEmitter>();
            if (soundEmitter != null)
            {
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

    public void PlayQuestCompleteSound()
    {
        if (questEndSoundEmitter != null)
        {
            var soundEmitter = questEndSoundEmitter.GetComponent<StudioEventEmitter>();
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

    public void PlayLeekGrabSound()
    {
        if (leekGrabSoundEmitter != null)
        {
            var soundEmitter = leekGrabSoundEmitter.GetComponent<StudioEventEmitter>();
            if (soundEmitter != null)
            {
                soundEmitter.Play();
            }
            else
            {
                Debug.LogError("Leek grab sound emitter is missing FMODUnity.StudioEventEmitter component.");
            }
        }
        else
        {
            Debug.LogError("Leek grab sound emitter is not assigned.");
        }
    }

    IEnumerator ErrorTimeout()
    {
        yield return new WaitForSeconds(0.25f);
        pressToTalkUI.SetActive(false);
        questStarted = true;
    }
}