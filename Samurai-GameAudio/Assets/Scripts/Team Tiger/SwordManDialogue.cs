using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwordManDialogue : MonoBehaviour
{
    public GameObject endquestTrigger;
    public GameObject questLogic;
    public TextMeshProUGUI subtitles;

    void Start()
    {
        subtitles.text = string.Empty;
    }

    void Update()
    {
        if (endquestTrigger.GetComponent<EndQuestTrigger>().playerInEndTrigger == true && questLogic.GetComponent<QuestLogic>().playerHasSword && Input.GetKeyDown(KeyCode.E))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/NPCs/Sword Man (Quest End)", this.transform.position);
            StartCoroutine(Dialogue("Emperor: Thank you my boy!"));
        }
    }

    IEnumerator Dialogue(string text)
    {
        subtitles.text = text;
        yield return new WaitForSeconds(3);
        subtitles.text = string.Empty;
    }
}