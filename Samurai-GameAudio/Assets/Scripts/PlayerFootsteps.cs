using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour {

    private enum CURRENT_TERRAIN { GRASS, GRAVEL, WOOD_FLOOR, WATER };

    [SerializeField]
    private CURRENT_TERRAIN currentTerrain;

    private FMOD.Studio.EventInstance foosteps;

    private ThirdPersonUserControl thirdPersonUserControl;

    private void Start()
    {
        thirdPersonUserControl = GetComponent<ThirdPersonUserControl>();
    }

    private void Update()
    {
        DetermineTerrain();
    }

    private void DetermineTerrain()
    {
        RaycastHit[] hit;

        // Originally set at 10.0f, but needs to be set to 0.25 for Robot scenario due to how the level is built.
        hit = Physics.RaycastAll(transform.position, Vector3.down, 0.25f);

        foreach (RaycastHit rayhit in hit)
        {
            if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Gravel"))
            {
                currentTerrain = CURRENT_TERRAIN.GRAVEL;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Wood"))
            {
                currentTerrain = CURRENT_TERRAIN.WOOD_FLOOR;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Grass"))
            {
                currentTerrain = CURRENT_TERRAIN.GRASS;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Water"))
            {
                currentTerrain = CURRENT_TERRAIN.WATER;
            }
        }
    }

    public void SelectAndPlayFootstep()
    {     
        switch (currentTerrain)
        {
            case CURRENT_TERRAIN.GRAVEL:
                PlayFootstep(0, thirdPersonUserControl.playerWalkType);
                break;

            case CURRENT_TERRAIN.GRASS:
                PlayFootstep(1, thirdPersonUserControl.playerWalkType);
                break;

            case CURRENT_TERRAIN.WOOD_FLOOR:
                PlayFootstep(2, thirdPersonUserControl.playerWalkType);
                break;

            case CURRENT_TERRAIN.WATER:
                PlayFootstep(3, thirdPersonUserControl.playerWalkType);
                break;
        }
    }

    private void PlayFootstep(int terrain, int walkType)
    {
        foosteps = FMODUnity.RuntimeManager.CreateInstance("event:/Footsteps");
        foosteps.setParameterByName("Terrain", terrain);
        foosteps.setParameterByName("Sound Level", walkType);
        foosteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        foosteps.start();
        foosteps.release();
    }
}