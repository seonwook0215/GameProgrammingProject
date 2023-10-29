using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    
    public static BattleManager instance;
    public float cameranum = -1;
    private float cnt = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("��Ʋ �Ŵ����� �ΰ��̻�!");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TurnManager.instance.Onattack&&cnt==0)
        {
            cnt = 1;
            Debug.Log("BMstart");
            selectPlace();
            
        }
        if (cameranum != -1)
        {
            //EndFight();
        }
    }

    private void EndFight()
    {
        switch (cameranum)
        {
            case 0:
                if ((PUnitManager.instance.P_units.Count + PUnitManager.instance.L_units.Count + PUnitManager.instance.A_units.Count) ==0|| 
                    (EUnitManager.instance.P_units.Count + EUnitManager.instance.L_units.Count + EUnitManager.instance.A_units.Count) == 0)
                {
                    ReturnArmy();
                    cameranum = -1;
                    
                }
                break;
            case 1:
                if (!EUnitManager.instance.fortress|| (PUnitManager.instance.P_units.Count + PUnitManager.instance.L_units.Count + PUnitManager.instance.A_units.Count) == 0)
                {
                    ReturnArmy();
                    cameranum = -1;
                }
                break;
            case 2:
                if (!EUnitManager.instance.castle || (PUnitManager.instance.P_units.Count + PUnitManager.instance.L_units.Count + PUnitManager.instance.A_units.Count) == 0)
                {
                    ReturnArmy();
                    cameranum = -1;
                }
                break;
            case 3:
                if (!PUnitManager.instance.fortress || (EUnitManager.instance.P_units.Count + EUnitManager.instance.L_units.Count + EUnitManager.instance.A_units.Count) == 0)
                {
                    ReturnArmy();
                    cameranum = -1;
                }
                break;
            case 4:
                if (!PUnitManager.instance.castle || (EUnitManager.instance.P_units.Count + EUnitManager.instance.L_units.Count + EUnitManager.instance.A_units.Count) == 0)
                {
                    ReturnArmy();
                    cameranum = -1;
                }
                break;
            default:
                break;

        }
    }

    private void ReturnArmy()
    {
        EUnitManager.instance.Archer = EUnitManager.instance.A_units.Count;
        EUnitManager.instance.Lancer = EUnitManager.instance.L_units.Count;
        EUnitManager.instance.Paladin = EUnitManager.instance.P_units.Count;
        PUnitManager.instance.Archer = PUnitManager.instance.A_units.Count;
        PUnitManager.instance.Lancer = PUnitManager.instance.L_units.Count;
        PUnitManager.instance.Paladin = PUnitManager.instance.P_units.Count;
   
}
    private void makeArmyzero()
    {
        EUnitManager.instance.Archer = 0;
        EUnitManager.instance.Lancer = 0;
        EUnitManager.instance.Paladin = 0;
        PUnitManager.instance.Archer = 0;
        PUnitManager.instance.Lancer = 0;
        PUnitManager.instance.Paladin = 0;
    }
    private void selectPlace()
    {
        if (TurnManager.instance.Onattack && EnemyManager.instance.Attack) //attack both ���
        {
            cameranum = 0;
            //ī�޶� �ű��
            //��߿� �ִ� �����ʿ� ���� �Ҵ�
            GameObject.Find("BattelFieldSpawner").GetComponent<EArcherSpawn>().num = EUnitManager.instance.Archer;
            GameObject.Find("BattelFieldSpawner").GetComponent<ELancerSpawn>().num = EUnitManager.instance.Lancer;
            GameObject.Find("BattelFieldSpawner").GetComponent<EPaladinSpawn>().num = EUnitManager.instance.Paladin;
            GameObject.Find("BattelFieldSpawner").GetComponent<PArcherSpawn>().num = PUnitManager.instance.Archer;
            GameObject.Find("BattelFieldSpawner").GetComponent<PLancerSpawn>().num = PUnitManager.instance.Lancer;
            GameObject.Find("BattelFieldSpawner").GetComponent<PPaladinSpawn>().num = PUnitManager.instance.Paladin;
        }
        else if (TurnManager.instance.Onattack) // player attack, enemy don't 
        {
            if (EUnitManager.instance.fortress)
            { //2������ �Ⱥμ�����
                cameranum = 1;
                GameObject.Find("1st Enemy Site Spawner").GetComponent<EArcherSpawn>().num = EUnitManager.instance.Archer;
                GameObject.Find("1st Enemy Site Spawner").GetComponent<ELancerSpawn>().num = EUnitManager.instance.Lancer;
                GameObject.Find("1st Enemy Site Spawner").GetComponent<EPaladinSpawn>().num = EUnitManager.instance.Paladin;
                GameObject.Find("1st Enemy Site Spawner").GetComponent<PArcherSpawn>().num = PUnitManager.instance.Archer;
                GameObject.Find("1st Enemy Site Spawner").GetComponent<PLancerSpawn>().num = PUnitManager.instance.Lancer;
                GameObject.Find("1st Enemy Site Spawner").GetComponent<PPaladinSpawn>().num = PUnitManager.instance.Paladin;
            }
            else
            { //2������ �μ���
                Debug.Log("2nd destroyed , lancer unit : " + PUnitManager.instance.Lancer);
                cameranum = 2;
                GameObject.Find("2nd Enemy Site Spawner").GetComponent<EArcherSpawn>().num = EUnitManager.instance.Archer;
                GameObject.Find("2nd Enemy Site Spawner").GetComponent<ELancerSpawn>().num = EUnitManager.instance.Lancer;
                GameObject.Find("2nd Enemy Site Spawner").GetComponent<EPaladinSpawn>().num = EUnitManager.instance.Paladin;
                GameObject.Find("2nd Enemy Site Spawner").GetComponent<PArcherSpawn>().num = PUnitManager.instance.Archer;
                GameObject.Find("2nd Enemy Site Spawner").GetComponent<PLancerSpawn>().num = PUnitManager.instance.Lancer;
                GameObject.Find("2nd Enemy Site Spawner").GetComponent<PPaladinSpawn>().num = PUnitManager.instance.Paladin;
            }
        }
        else if (EnemyManager.instance.Attack) //enemy attack, player don't
        {
            if (PUnitManager.instance.fortress)
            { //2������ �Ⱥμ�����
                cameranum = 3;
                GameObject.Find("1st Player Site Spawner").GetComponent<EArcherSpawn>().num = EUnitManager.instance.Archer;
                GameObject.Find("1st Player Site Spawner").GetComponent<ELancerSpawn>().num = EUnitManager.instance.Lancer;
                GameObject.Find("1st Player Site Spawner").GetComponent<EPaladinSpawn>().num = EUnitManager.instance.Paladin;
                GameObject.Find("1st Player Site Spawner").GetComponent<PArcherSpawn>().num = PUnitManager.instance.Archer;
                GameObject.Find("1st Player Site Spawner").GetComponent<PLancerSpawn>().num = PUnitManager.instance.Lancer;
                GameObject.Find("1st Player Site Spawner").GetComponent<PPaladinSpawn>().num = PUnitManager.instance.Paladin;
            }
            else
            { //2������ �μ���
                cameranum = 4;
                GameObject.Find("2nd Player Site Spawner").GetComponent<EArcherSpawn>().num = EUnitManager.instance.Archer;
                GameObject.Find("2nd Player Site Spawner").GetComponent<ELancerSpawn>().num = EUnitManager.instance.Lancer;
                GameObject.Find("2nd Player Site Spawner").GetComponent<EPaladinSpawn>().num = EUnitManager.instance.Paladin;
                GameObject.Find("2nd Player Site Spawner").GetComponent<PArcherSpawn>().num = PUnitManager.instance.Archer;
                GameObject.Find("2nd Player Site Spawner").GetComponent<PLancerSpawn>().num = PUnitManager.instance.Lancer;
                GameObject.Find("2nd Player Site Spawner").GetComponent<PPaladinSpawn>().num = PUnitManager.instance.Paladin;
            }
        }
        else //don't attack both
        {

        }
        makeArmyzero();
    }
}
