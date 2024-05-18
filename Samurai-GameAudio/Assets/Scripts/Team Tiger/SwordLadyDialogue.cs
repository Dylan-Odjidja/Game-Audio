using System.Collections;
using TMPro;
using UnityEngine;

public class SwordLadyDialogue : MonoBehaviour
{
    public GameObject pickupTrigger;
    public TextMeshProUGUI subtitles;

    void Start()
    {
        subtitles.text = string.Empty;
    }

    void Update()
    {
        if (pickupTrigger.GetComponent<SwordPickup>().playerCanPickupSword == true && Input.GetKeyDown(KeyCode.E))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/NPCs/Sword Lady (Quest Start)", this.transform.position);
            StartCoroutine(Dialogue("Sword Lady: Please return this to the Emperor."));
        }
    }

    IEnumerator Dialogue(string text)
    {
        subtitles.text = text;
        yield return new WaitForSeconds(3);
        subtitles.text = string.Empty;
    }
}