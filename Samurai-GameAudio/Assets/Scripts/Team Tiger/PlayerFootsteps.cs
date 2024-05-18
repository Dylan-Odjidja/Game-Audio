using UnityEngine;

public class PlayerFootsteps : MonoBehaviour {

    private enum CURRENT_TERRAIN { GRASS, GRAVEL, WOOD, WATER, CONCRETE };

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
                currentTerrain = CURRENT_TERRAIN.WOOD;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Grass"))
            {
                currentTerrain = CURRENT_TERRAIN.GRASS;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Water"))
            {
                currentTerrain = CURRENT_TERRAIN.WATER;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Concrete"))
            {
                currentTerrain = CURRENT_TERRAIN.CONCRETE;
                break;
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

            case CURRENT_TERRAIN.WOOD:
                PlayFootstep(2, thirdPersonUserControl.playerWalkType);
                break;

            case CURRENT_TERRAIN.WATER:
                PlayFootstep(3, thirdPersonUserControl.playerWalkType);
                break;

            case CURRENT_TERRAIN.CONCRETE:
                PlayFootstep(4, thirdPersonUserControl.playerWalkType);
                break;

            default:
                PlayFootstep(5, 2);
                break;
        }
    }

    private void PlayFootstep(int terrain, int walkType)
    {
        foosteps = FMODUnity.RuntimeManager.CreateInstance("event:/Player/Footsteps");
        foosteps.setParameterByName("Terrain", terrain);
        foosteps.setParameterByName("Sound Level", walkType);
        foosteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        foosteps.start();
        foosteps.release();
    }
}