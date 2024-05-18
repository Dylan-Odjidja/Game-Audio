using UnityEngine;

public class PlayerWarp : MonoBehaviour
{
    public Transform warpMarker1;
    public Transform warpMarker2;
    public Transform warpMarker3;
    public Transform warpMarker4;
    public Transform warpMarker5;
    public Transform warpMarker6;

    public Transform playerStartLocation;
    public Transform player;

    void Awake()
    {
        player.position = playerStartLocation.position;
        player.rotation = playerStartLocation.rotation; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.position = warpMarker1.position;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Warp", this.transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.position = warpMarker2.position;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Warp", this.transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.position = warpMarker3.position;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Warp", this.transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            player.position = warpMarker4.position;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Warp", this.transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            player.position = warpMarker5.position;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Warp", this.transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            player.position = warpMarker6.position;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Warp", this.transform.position);
        }
    }
}