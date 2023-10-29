using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject Player;
    public GameObject Enemy;

    public float Day;
    public float Phase;
    private int person;

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
    private void Start()
    {
        person = PersonController.instance.cur; //0 leo 1 lee 3 na

    }


}
