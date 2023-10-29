using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    public GameObject ResourceManger;
    public GameObject BuildingManger;
    public GameObject UnitManger;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("�Ŵ����� �ΰ��̻�!");
            Destroy(gameObject);
        }
    }
}
