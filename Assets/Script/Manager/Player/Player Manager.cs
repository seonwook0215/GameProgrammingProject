using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public GameObject ResourceManger;
    public GameObject BuildingManger;
    public GameObject UnitManger;
    public bool Attack = false;
    public float attackday;
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
