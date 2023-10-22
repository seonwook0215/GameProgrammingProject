using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUnitManager : MonoBehaviour // ���� �󸶳� �ִ��� ����
{
    public static PUnitManager instance;
    private float pos_x;
    private float pos_y;
    private float pos_z;
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

    public List<PUnit> units;
    public List<PPaladin> P_units;
    public List<PLancer> L_units;
    public List<PArcher> A_units;

    public List<Vector3> unit_position;

    private void FixedUpdate()
    {
        pos_x = pos_y = pos_z = 0;
        foreach(PUnit u in units)
        {
            pos_x += u.transform.position.x;
            pos_y += u.transform.position.y;
            pos_z += u.transform.position.z;
        }

    }
    private void Update()
    {
        float count = units.Count;
        
        pos = new Vector3(pos_x / count, pos_y / count, pos_z / count);
        
        enemy_pos = EUnitManager.instance.pos;
    }
}
