using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTriggerMusic : MonoBehaviour
{
    public BackgroundMusicController musicController;

    // Call this method when the quest starts
    public void StartQuest()
    {
        musicController.SwitchToQuestMusic();
    }

    // Call this method when the quest ends
    public void EndQuest()
    {
        musicController.SwitchToDefaultMusic();
    }
}

