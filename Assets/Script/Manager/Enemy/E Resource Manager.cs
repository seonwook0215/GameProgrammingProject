using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EResourceManager : MonoBehaviour //�ڿ� �󸶳� �ִ��� ����
{
    public static EResourceManager instance;
    public float MP;
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
        MP = 150;
    }
}
