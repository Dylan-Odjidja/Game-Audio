using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class UIBobAnim : MonoBehaviour
{
    //public StudioEventEmitter popupSoundEmitter; // Assign the FMOD StudioEventEmitter component for the popup sound in the Inspector

    float topDistance = 0.004f;
    float bottomDistance = -0.004f;
    float t = 0.0f;

    void Update()
    {
        this.transform.localPosition += new Vector3(0, Mathf.Lerp(bottomDistance, topDistance, t), 0);

        t += 0.5f * Time.deltaTime;

        if (t > 1.0f)
        {
            float temp = topDistance;
            topDistance = bottomDistance;
            bottomDistance = temp;
            t = 0.0f;

            // Play the popup sound when the menu pops up
           // if (popupSoundEmitter != null)
            //{
               // popupSoundEmitter.Play();
           // }
        }
    }
}
