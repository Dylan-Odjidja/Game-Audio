using UnityEngine;
using FMODUnity;
using System.Collections;

public class GongSound : MonoBehaviour
{
    public StudioEventEmitter gongSound;
    public GongTriggerBox gongTriggerBox;

    internal bool playable;

    private void Start()
    {
        playable = true;
    }

    void Update()
    {
        PlayGong();
    }

    void PlayGong()
    {
        if (gongTriggerBox.playerIsInTrigger == true && Input.GetKeyDown(KeyCode.E) && playable == true)
        {
            gongSound.Play();
            StartCoroutine(GongTimeout());
        }
    }

    IEnumerator GongTimeout()
    {
        playable = false;
        yield return new WaitForSeconds(2);
        playable = true;
    }
}