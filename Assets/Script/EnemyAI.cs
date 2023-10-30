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
        //처음 시작 200원 시작
        switch (Day)
        {
            //Day 1 자원
            case 0:
                Debug.Log(Day);
                Instantiate(ResourceBuilding, position1, Quaternion.identity);
                break;
            //Day 2 자원
            case 1:
                Debug.Log(Day);
                Instantiate(ResourceBuilding, position2, Quaternion.identity);
                break;
            //Day 3 창   공격x
            case 2:
                Debug.Log(Day);
                Instantiate(LancerBuilding, position3, Quaternion.identity);
                
                break;
            //Day 4 자원
            case 3:
                Debug.Log(Day);
                Instantiate(ResourceBuilding, position4, Quaternion.identity);
                break;
            //Day 5 검
            case 4:
                Debug.Log(Day);
                Instantiate(SwordBuilding, position5, Quaternion.identity);
                break;
            //Day 6 창   공격o
            case 5:
                Debug.Log(Day);
                Instantiate(LancerBuilding, position6, Quaternion.identity);
                TurnManager.instance.EnemyAttack = true;
                Debug.Log("전쟁을 ㅣㅅ작하자");
                break;
            //Day 7 궁
            case 6:
                TurnManager.instance.EnemyAttack = false;
                Debug.Log(Day);
                Instantiate(ArcherBuilding, position7, Quaternion.identity);
                break;
            //Day 8 검
            case 7:
                Debug.Log(Day);
                Instantiate(SwordBuilding, position8, Quaternion.identity);
                break;
            //Day 9 창   공격o
            case 8:
                Debug.Log(Day);
                Instantiate(LancerBuilding, position9, Quaternion.identity);
                TurnManager.instance.EnemyAttack = true;
                break;
            //Day 10궁
            case 9:
                TurnManager.instance.EnemyAttack = false;
                Debug.Log(Day);
                Instantiate(ArcherBuilding, position10, Quaternion.identity);
                break;
            //Day 11검
            case 10:
                Debug.Log(Day);
                Instantiate(SwordBuilding, position11, Quaternion.identity);
                break;
            //Day 12궁   공격o
            case 11:
                Debug.Log(Day);
                Instantiate(ArcherBuilding, position12, Quaternion.identity);
                TurnManager.instance.EnemyAttack = true;
                break;
            case 12:
                TurnManager.instance.EnemyAttack = false;
                Debug.Log(Day);
                break;
            case 13:
                Debug.Log(Day);
                break;
            case 14:
                Debug.Log(Day);
                TurnManager.instance.EnemyAttack = true;
                break;
            case 15:
                TurnManager.instance.EnemyAttack = false;
                Debug.Log(Day);
                break;
            case 16:
                Debug.Log(Day);
                break;
            case 17:
                Debug.Log(Day);
                TurnManager.instance.EnemyAttack = true;
                break;
            case 18:
                TurnManager.instance.EnemyAttack = false;
                Debug.Log(Day);
                break;
            case 19:
                Debug.Log(Day);
                TurnManager.instance.EnemyAttack = true;
                break;
            case 20:
                Debug.Log(Day);
                //TurnManager.instance.EnemyAttack = true;
                break;
            //마지막 전투 후 끝

        }

    }
}
