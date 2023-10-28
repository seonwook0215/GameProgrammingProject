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

    [SerializeField] private GameObject firstphase;
    [SerializeField] private GameObject firstXbutton;
    [SerializeField] private GameObject secondphase;
    [SerializeField] private GameObject secondXbutton;
    [SerializeField] private GameObject thirdphase;
    [SerializeField] private GameObject thirdXbutton;
    [SerializeField] private GameObject thirdAttackbutton;

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
        Day++;
        Phase1();
    }
    public void TurnEnd()
    {

    }
    public void Phase1() //�����̶� ��
    {
        if (Day == 1) //ù���� �Ⱥ����൵��  
        {
            Debug.Log(Day);
            Phase2();
        }
        else
        {
            Debug.Log("Phase1 start");
            Debug.Log(Day);
            Turn_phase1.instance.phase1 = true;
            thirdphase.SetActive(false);
            firstphase.SetActive(true);
            
        }
    }
    public void Phase2() // �ǹ� ����
    {
        firstphase.SetActive(false);
        secondphase.SetActive(true);
        Turn_phase1.instance.phase1 = false;
        
        Debug.Log("Phase2 start");
    }
    public void Phase3() // ���ݿ��� ����
    {
        secondphase.SetActive(false);
        thirdphase.SetActive(true);
        
    }
}
