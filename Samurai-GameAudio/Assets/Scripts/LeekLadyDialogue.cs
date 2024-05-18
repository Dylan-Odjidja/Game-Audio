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
        if (marketSellerTrigger.GetComponent<MarketSellerTrigger>().playerIsInMarketSellerTrigger == true && theLeekQuest.GetComponent<TheLeekQuest>().questStarted == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/NPCs/Leek Lady (Quest Start)", this.transform.position);
                StartCoroutine(Dialogue());
            }
        }
    }

    IEnumerator Dialogue()
    {
        subtitles.text = "Leek Lady: Please can you grab me a leek?";
        yield return new WaitForSeconds(3);
        subtitles.text = string.Empty;
    }
}