using TMPro;
using UnityEngine;

public class GongTriggerBox : MonoBehaviour
{
    internal bool playerIsInTrigger;
    public TextMeshProUGUI text;
    public GongSound gongSound;

    void Start() 
    {
        playerIsInTrigger = false;
        text.text = string.Empty;
    }

    private void Update()
    {
        if (gongSound.playable == true && playerIsInTrigger == true)
        {
            text.text = "Press 'E' to hit gong!";
        }
        else
        {
            text.text = string.Empty;
        }
    }

    void OnTriggerEnter (Collider player) 
    {
        if (player.gameObject.tag == "Player") 
        {
            playerIsInTrigger = true;
        }
    }

    void OnTriggerExit (Collider player) 
    {
        if (player.gameObject.tag == "Player") 
        {
            playerIsInTrigger = false;
        }
    }
}