using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBuildingManager: MonoBehaviour //� �ǹ��� � �������ִ��� ����
{
    public static EBuildingManager instance;

    //public GameObject buildingmanager;

    public List<EResourceBuilding> R_building;
    public List<EPaladinUnitBuilding> P_building;
    public List<ELancerUnitBuilding> L_building;
    public List<EArcherUnitBuilding> A_building;
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
