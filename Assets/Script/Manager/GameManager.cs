using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagaer : MonoBehaviour
{
    public static GameManagaer instance;

    public GameObject Player;
    public GameObject Enemy;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("���� �Ŵ����� �ΰ��̻�!");
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Life>().amount <= 0) //Player lose
        {

        }
        else if (Enemy.GetComponent<Life>().amount <= 0) //Enemy lose
        {

        }
    }

    void Phase1() //�����̶� ��
    {

    }
    void Phase2() //�ǹ�, ���� ����, ����
    {

    }
    void Phase3() // 3Day���� ���ݿ��� ����
    {

    }
}
