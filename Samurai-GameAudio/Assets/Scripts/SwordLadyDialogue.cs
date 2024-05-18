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
            StartCoroutine(Dialogue());
        }
    }

    IEnumerator Dialogue()
    {
        subtitles.text = "Sword Lady: Please return this to the Emperor.";
        yield return new WaitForSeconds(3);
        subtitles.text = string.Empty;
    }
}