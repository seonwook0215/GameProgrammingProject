using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBuildingManager: MonoBehaviour //� �ǹ��� � �������ִ��� ����
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

    private void Update()
    {
        
    }

}
