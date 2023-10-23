using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnManager: MonoBehaviour
{
    public static TurnManager instance;

    public float Day;
    public float Phase;
    public GameObject firstphase;
    public GameObject Xbutton;

    private float Paladin;
    private float Lancer;
    private float Archer;
    private float MP;
    private float R_building;
    private float P_building;
    private float L_building;
    private float A_building;
    //private float Fortress_hp;
    //private float Castle_hp;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Duplicated Turn, ignoring this one", gameObject);
        }
    }
    private void Start()
    {
        Day = 0;
        TurnStart();
    }

    public void TurnStart()
    {
        
        Phase1();
        Day++;
    }
    public void TurnEnd()
    {

    }
    public void Phase1() //�����̶� ��
    {
        if (Day == 1) //ù���� �Ⱥ����൵��  
        {
            Debug.Log(Day);
        }
        else
        {
            Debug.Log("Phase1 start");
            Debug.Log(Day);
            Turn_phase1.instance.phase1 = true;
            firstphase.SetActive(true);
            Xbutton.SetActive(true);
        }
    }
    public void Phase2() // �ǹ� ����
    {
        Turn_phase1.instance.phase1 = false;
        firstphase.SetActive(false);
        Xbutton.SetActive(false);
        Debug.Log("Phase2 start");
    }
    public void Phase3() // ���ݿ��� ����
    {
        
    }
}
