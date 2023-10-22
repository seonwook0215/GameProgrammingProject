using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBuildingManager: MonoBehaviour //어떤 건물이 몇개 지어져있는지 관리
{
    public static PBuildingManager instance;

    //public GameObject buildingmanager;

    public List<PResourceBuilding> R_building;
    public List<PPaladinUnitBuilding> P_building;
    public List<PLancerUnitBuilding> L_building;
    public List<PArcherUnitBuilding> A_building;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Duplicated BuildingManager, ignoring this one", gameObject);
        }
    }

}
