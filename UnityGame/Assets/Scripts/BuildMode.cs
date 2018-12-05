using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildMode : MonoBehaviour
{

    [SerializeField] GameObject wall, foodStorage, ResourceStorage, FireAntPrison;
    private bool canPlace = false;
    private bool VisualizeBuildingReady = false;
    [SerializeField] Material Green, Red;
    private GameObject selectedBuilding;
    private GameObject buildingToBuild;
    public Camera screenCam;


    private enum BuildingType
    {
        wall,
        foodStorage,
        ResourceStorage,
        FireAntPrison
    }
    BuildingType m_BuildingSelected;

    // Use this for initialization
    void Start()
    {
        TESTINGONLY();
    }

    // Update is called once per frame
    void Update()
    {
        VisulizeStructurePlacement();
    }

    private void TESTINGONLY() //TODO this is for testing purposes only, after It is tested, remove this
    {
        selectedBuilding = wall;

    }
    private void CreateTestBuilding()
    {

    }

    private void VisulizeStructurePlacement()
    {
        RaycastHit hit;
        Ray ray = screenCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && !VisualizeBuildingReady)
        {
            buildingToBuild = Instantiate(selectedBuilding, hit.point, Quaternion.identity);
            buildingToBuild.GetComponent<BoxCollider>().isTrigger = true; //TODO remove this after testing
            buildingToBuild.GetComponent<NavMeshObstacle>().enabled = false;
            VisualizeBuildingReady = true;
        }
        if (Physics.Raycast(ray, out hit))
        {
            float hMovement = Input.GetAxis("Horizontal");
            buildingToBuild.transform.position = hit.point + (Vector3.up / 2);
            buildingToBuild.transform.eulerAngles = (buildingToBuild.transform.eulerAngles + new Vector3(0, hMovement, 0));
        }
    }
    //set type of building that was selected
    private void SetTypeOfBuilding(BuildingType buildType)
    {
        m_BuildingSelected = buildType;
        switch (buildType)
        {
            case BuildingType.wall:
                selectedBuilding = wall;
                selectedBuilding.GetComponent<BoxCollider>().enabled = false;
                break;
            case BuildingType.foodStorage:
                selectedBuilding = foodStorage;
                break;
            case BuildingType.ResourceStorage:
                selectedBuilding = ResourceStorage;
                break;
            case BuildingType.FireAntPrison:
                selectedBuilding = FireAntPrison;
                break;
            default:
                Debug.Log("If you are seeing this, it means something went wrong in the build menu. Consult Jonathan for support.");
                break;
        }
    }

}
