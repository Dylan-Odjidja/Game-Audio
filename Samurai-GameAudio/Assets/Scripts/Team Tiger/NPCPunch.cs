using UnityEngine;

public class NPCPunch : MonoBehaviour
{
    private FMOD.Studio.EventInstance punches;

    public void Punch_One()
    {
        punches = FMODUnity.RuntimeManager.CreateInstance("event:/NPCs/Boxing");
        punches.setParameterByName("Punches", 0);
        punches.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        punches.start();
        punches.release();
    }

    public void Punch_Two()
    {
        punches = FMODUnity.RuntimeManager.CreateInstance("event:/NPCs/Boxing");
        punches.setParameterByName("Punches", 2);
        punches.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        punches.start();
        punches.release();
    }
}