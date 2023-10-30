using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float Day;
    public GameObject ResourceBuilding;
    public GameObject SwordBuilding;
    public GameObject LancerBuilding;
    public GameObject ArcherBuilding;

    Vector3 position1 = new Vector3(415, 20, 69);
    Vector3 position2 = new Vector3(415, 20, 55);
    Vector3 position3 = new Vector3(283, 3, 29);//�װ�
    Vector3 position4 = new Vector3(412, 13, 5);
    Vector3 position5 = new Vector3(282, 3, 15);//�װ�
    Vector3 position6 = new Vector3(411, 10, -19);
    Vector3 position7 = new Vector3(321, 3, -20);//�װ�
    Vector3 position8 = new Vector3(291, 3, -34);//�װ�
    Vector3 position9 = new Vector3(406, 4, -51);
    Vector3 position10 = new Vector3(405, 4, -67);
    Vector3 position11 = new Vector3(375, 4, -51);
    Vector3 position12 = new Vector3(376, 4, -67);

    private void Start()
    {
        Day = 0;
    }
    private void Update()
    {
        if (TurnManager.instance.Day > Day)
        {
            Debug.Log("AI act");
            Alact();
            Day = TurnManager.instance.Day;
        }
        
    }

    private void Alact() {
        //ó�� ���� 200�� ����
        switch (Day)
        {
            //Day 1 �ڿ�
            case 0:
                Instantiate(ResourceBuilding, position1, Quaternion.identity);
                break;
            //Day 2 �ڿ�
            case 1:
                Instantiate(ResourceBuilding, position2, Quaternion.identity);
                break;
            //Day 3 â   ����x
            case 2:
                if (EUnitManager.instance.fortress)
                {
                    Instantiate(LancerBuilding, position3, Quaternion.identity);
                }
                
                break;
            //Day 4 �ڿ�
            case 3:
                Instantiate(ResourceBuilding, position4, Quaternion.identity);
                break;
            //Day 5 ��
            case 4:
                if (EUnitManager.instance.fortress)
                {
                    Instantiate(SwordBuilding, position5, Quaternion.identity);
                }
                break;
            //Day 6 â   ����o
            case 5:


                Instantiate(LancerBuilding, position6, Quaternion.identity);
                TurnManager.instance.EnemyAttack = true;
                Debug.Log("������ �Ӥ�������");
                break;
            //Day 7 ��
            case 6:
                if (EUnitManager.instance.fortress)
                {
                    Instantiate(ArcherBuilding, position7, Quaternion.identity);
                }
                break;
            //Day 8 ��
            case 7:
                if (EUnitManager.instance.fortress)
                {
                    Instantiate(SwordBuilding, position8, Quaternion.identity);
                }
                break;
            //Day 9 â   ����o
            case 8:
                Instantiate(LancerBuilding, position9, Quaternion.identity);
                TurnManager.instance.EnemyAttack = true;
                break;
            //Day 10��
            case 9:
                Instantiate(ArcherBuilding, position10, Quaternion.identity);
                break;
            //Day 11��
            case 10:
                Instantiate(SwordBuilding, position11, Quaternion.identity);
                break;
            //Day 12��   ����o
            case 11:
                Instantiate(ArcherBuilding, position12, Quaternion.identity);
                TurnManager.instance.EnemyAttack = true;
                break;
            case 12:
                break;
            case 13:
                break;
            case 14:
                TurnManager.instance.EnemyAttack = true;
                break;
            case 15:
                break;
            case 16:
                break;
            case 17:
                TurnManager.instance.EnemyAttack = true;
                break;
            case 18:
                break;
            case 19:
                TurnManager.instance.EnemyAttack = true;
                break;
            case 20:
                //TurnManager.instance.EnemyAttack = true;
                break;
            //������ ���� �� ��

        }

    }
}
