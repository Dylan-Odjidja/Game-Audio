using System.Collections;
using TMPro;
using UnityEngine;

public class LeekLadyDialogue : MonoBehaviour
{
    public GameObject marketSellerTrigger;
    public GameObject theLeekQuest;
    public TextMeshProUGUI subtitles;

    void Start()
    {
        subtitles.text = string.Empty;
    }

    void Update()
    {
        if (marketSellerTrigger.GetComponent<MarketSellerTrigger>().playerIsInMarketSellerTrigger == true 
            && theLeekQuest.GetComponent<TheLeekQuest>().questStarted == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/NPCs/Leek Lady (Quest Start)", transform.position);
                StartCoroutine(Dialogue("Leek Lady: Please can you grab me a leek?"));
            }
        }

        if (theLeekQuest.GetComponent<TheLeekQuest>().doesPlayerHaveLeek == true 
            && marketSellerTrigger.GetComponent<MarketSellerTrigger>().playerIsInMarketSellerTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/NPCs/Leek Lady (Quest End)", transform.position);
                StartCoroutine(Dialogue("Leek Lady: Thank You!"));
            }
        }
    }

    IEnumerator Dialogue(string text)
    {
        subtitles.text = text;
        yield return new WaitForSeconds(3);
        subtitles.text = string.Empty;
    }
}