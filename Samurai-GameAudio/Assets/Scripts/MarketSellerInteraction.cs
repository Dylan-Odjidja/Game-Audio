using UnityEngine;
using FMODUnity;

public class MarketSellerInteraction : MonoBehaviour
{
    public StudioEventEmitter backgroundMusicEmitter;

    // Call this method when the player interacts with the market seller
    public void InteractWithMarketSeller()
    {
        // Check if the background music emitter is assigned
        if (backgroundMusicEmitter != null)
        {
            // Set the parameter to indicate that the player is in quest mode
            /*backgroundMusicEmitter.setParameter("QUEST", 1);*/ // Assuming "InQuest" is the correct parameter name
        }
        else
        {
            Debug.LogError("Background music emitter is not assigned.");
        }
    }

    // Call this method when the player finishes the quest or leaves the market seller
    public void EndMarketSellerInteraction()
    {
        // Check if the background music emitter is assigned
        if (backgroundMusicEmitter != null)
        {
            // Set the parameter to indicate that the player is not in quest mode
            /*backgroundMusicEmitter.setParameter("QUEST", 0);*/ // Assuming "InQuest" is the correct parameter name
        }
        else
        {
            Debug.LogError("Background music emitter is not assigned.");
        }
    }
}
