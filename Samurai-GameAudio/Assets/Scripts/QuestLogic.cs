using FMODUnity;
using UnityEngine;

public class QuestLogic : MonoBehaviour
{
    public GameObject emperorsSword;
    public GameObject emperorsSwordEnd;

    public GameObject pickupTrigger;

    public GameObject pickupUI;
    public GameObject giveUI;
    public GameObject dontHaveSwordUI;
    public GameObject pickupInventory;

    public GameObject endquestTrigger;

    public GameObject swordGrabEmitter;

    bool questComplete;

    public bool playerHasEnteredSwordTrigger;
    public bool playerHasSword;

    // Start is called before the first frame update
    void Start()
    {
        playerHasSword = false;
        pickupUI.SetActive(false);
        giveUI.SetActive(false);
        dontHaveSwordUI.SetActive(false);
        pickupInventory.SetActive(false);
        questComplete = false;
        emperorsSwordEnd.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayUI();
        PickupSword();
        EndQuest();
    }

    void PickupSword()
    {
        if (pickupTrigger.GetComponent<SwordPickup>().playerCanPickupSword == true && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(emperorsSword);
            playerHasSword = true;
            pickupUI.SetActive(false);
            pickupInventory.SetActive(true);
            pickupTrigger.GetComponent<SwordPickup>().PlaySwordQuestStartSound();
            PlaySwordGrabSound();
        }
    }
    void EndQuest()
    {
        if (endquestTrigger.GetComponent<EndQuestTrigger>().playerInEndTrigger == true && playerHasSword && Input.GetKeyDown(KeyCode.E))
        {
            questComplete = true;
            emperorsSwordEnd.SetActive(true);
            pickupUI.SetActive(false);
            playerHasSword = false;
            pickupInventory.SetActive(false);
            endquestTrigger.GetComponent<EndQuestTrigger>().PlayQuestCompletionSound();
        }
        else if (endquestTrigger.GetComponent<EndQuestTrigger>().playerInEndTrigger == true && !playerHasSword && Input.GetKeyDown(KeyCode.E) && !questComplete)
        {
            RuntimeManager.PlayOneShot("event:/Interactable/Quest Error", this.transform.position);
        }
    }
    void DisplayUI()
    {
        //UI for Pickup
        if (pickupTrigger.GetComponent<SwordPickup>().playerCanPickupSword == true && !playerHasSword)
        {
            pickupUI.SetActive(true);
        }
        else if (pickupTrigger.GetComponent<SwordPickup>().playerCanPickupSword == false && !playerHasSword)
        {
            pickupUI.SetActive(false);
        }

        //UI for End
        if (endquestTrigger.GetComponent<EndQuestTrigger>().playerInEndTrigger == true && playerHasSword && !questComplete)
        {
            giveUI.SetActive(true);
            dontHaveSwordUI.SetActive(false);
        }
        else if (endquestTrigger.GetComponent<EndQuestTrigger>().playerInEndTrigger == true && !playerHasSword && !questComplete)
        {
            giveUI.SetActive(true);
            dontHaveSwordUI.SetActive(false);
        }
        else if (endquestTrigger.GetComponent<EndQuestTrigger>().playerInEndTrigger == false)
        {
            giveUI.SetActive(false);
            dontHaveSwordUI.SetActive(false);
        }

        //Hide all UI when complete
        if (questComplete == true)
        {
            dontHaveSwordUI.SetActive(false);
            giveUI.SetActive(false);
            pickupUI.SetActive(false);
            
        }
    }

    public void PlaySwordGrabSound()
    {
        if (swordGrabEmitter != null)
        {
            var soundEmitter = swordGrabEmitter.GetComponent<StudioEventEmitter>();
            if (soundEmitter != null)
            {
                soundEmitter.Play();
            }
            else
            {
                Debug.LogError("Sword grab sound emitter is missing FMODUnity.StudioEventEmitter component.");
            }
        }
        else
        {
            Debug.LogError("Sword grab sound emitter is not assigned.");
        }
    }
}