using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TurnManager.instance.Onattack && EnemyManager.instance.Attack) //attack both
        {
            //��߿� �ִ� �����ʿ� ���� �Ҵ�
            
        }
        else if (TurnManager.instance.Onattack) // player attack, enemy don't
        {

        }
        else if (EnemyManager.instance.Attack) //enemy attack, player don't
        {

        }
        else //don't attack both
        {

        }
    }
}
