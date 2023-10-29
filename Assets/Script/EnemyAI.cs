using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float Day = TurnManager.instance.Day;
    public GameObject ResourceBuilding;
    public GameObject SwordBuilding;
    public GameObject LancerBuilding;
    public GameObject ArcherBuilding;

    Vector3 position1 = new Vector3(415, 20, 69);
    Vector3 position2 = new Vector3(415, 20, 55);
    Vector3 position3 = new Vector3(283, 3, 29);
    Vector3 position4 = new Vector3(412, 13, 5);
    Vector3 position5 = new Vector3(282, 3, 15);
    Vector3 position6 = new Vector3(411, 10, -19);
    Vector3 position7 = new Vector3(321, 3, -20);
    Vector3 position8 = new Vector3(291, 3, -34);
    Vector3 position9 = new Vector3(406, 4, -51);
    Vector3 position10 = new Vector3(405, 4, -67);
    Vector3 position11 = new Vector3(375, 4, -51);
    Vector3 position12 = new Vector3(376, 4, -67);

    private void FixedUpdate()
    {

    }

    void AIact()
    {
        //처음 시작 200원 시작
        switch (Day)
        {
            //Day 1 자원
            case 1:
                Instantiate(ResourceBuilding, position1, Quaternion.identity);
                break;
            //Day 2 자원
            case 2:
                Instantiate(ResourceBuilding, position2, Quaternion.identity);
                break;
            //Day 3 창   공격x
            case 3:
                Instantiate(LancerBuilding, position3, Quaternion.identity);
                EnemyManager.instance.Attack = false;
                break;
            //Day 4 자원
            case 4:
                Instantiate(ResourceBuilding, position4, Quaternion.identity);
                break;
            //Day 5 검
            case 5:
                Instantiate(SwordBuilding, position5, Quaternion.identity);
                break;
            //Day 6 창   공격o
            case 6:
                Instantiate(LancerBuilding, position6, Quaternion.identity);
                EnemyManager.instance.Attack = true;
                break;
            //Day 7 궁
            case 7:
                Instantiate(ArcherBuilding, position7, Quaternion.identity);
                break;
            //Day 8 검
            case 8:
                Instantiate(SwordBuilding, position8, Quaternion.identity);
                break;
            //Day 9 창   공격o
            case 9:
                Instantiate(LancerBuilding, position9, Quaternion.identity);
                EnemyManager.instance.Attack = true;
                break;
            //Day 10궁
            case 10:
                Instantiate(ArcherBuilding, position10, Quaternion.identity);
                break;
            //Day 11검
            case 11:
                Instantiate(SwordBuilding, position11, Quaternion.identity);
                break;
            //Day 12궁   공격o
            case 12:
                Instantiate(ArcherBuilding, position12, Quaternion.identity);
                EnemyManager.instance.Attack = true;
                break;
            case 13:
                break;
            case 14:
                break;
            case 15: //마지막 전투 후 끝
                break;

        }
    }
}
