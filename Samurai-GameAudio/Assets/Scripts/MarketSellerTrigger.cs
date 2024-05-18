using UnityEngine;

public class MarketSellerTrigger : MonoBehaviour
{
    public bool playerIsInMarketSellerTrigger;
    
    void Start()
    {
        playerIsInMarketSellerTrigger = false;
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            playerIsInMarketSellerTrigger = true;
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            playerIsInMarketSellerTrigger = false;
        }
    }
}
