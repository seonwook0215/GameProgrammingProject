using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EUnitManager : MonoBehaviour
{
    public static EUnitManager instance;
    private float pos_x;
    private float pos_y;
    private float pos_z;
    public float Paladin;
    public float Lancer;
    public float Archer;
    public Vector3 pos;
    public Vector3 enemy_pos;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Duplicated UnitManager, ignoring this one", gameObject);
        }
    }
    // Start is called before the first frame update

    public List<EUnit> units;
    public List<EPaladin> P_units;
    public List<ELancer> L_units;
    public List<EArcher> A_units;
    public List<Vector3> unit_position;

    private void FixedUpdate()
    {
        Paladin = EBuildingManager.instance.P_building.Count * 10;
        Lancer = EBuildingManager.instance.L_building.Count * 10;
        Archer = EBuildingManager.instance.A_building.Count * 10;

        pos_x = pos_y = pos_z = 0;
        foreach (EUnit u in units)
        {
            pos_x += u.transform.position.x;
            pos_y += u.transform.position.y;
            pos_z += u.transform.position.z;
        }
    }
    private void Update()
    {
        float count = units.Count;
        //Debug.Log("P2 " + count);
        pos = new Vector3(pos_x / count, pos_y / count, pos_z / count);
        enemy_pos = PUnitManager.instance.pos;
    }
}
