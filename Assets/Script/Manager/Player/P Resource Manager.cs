using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PResourceManager : MonoBehaviour //�ڿ� �󸶳� �ִ��� ����
{
    public static PResourceManager instance;
    public float MP;
    private float TurnChange;
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
        MP = 500;
    }
    private void Start()
    {
        TurnChange = TurnManager.instance.Day;
    }
    private void Update()
    {
        if (TurnChange != TurnManager.instance.Day)
        {
            TurnChangeGainMP();
            TurnChange = TurnManager.instance.Day;
        }
    }
    private void TurnChangeGainMP()
    {
        MP += PBuildingManager.instance.R_building.Count * 150;
    }
}
