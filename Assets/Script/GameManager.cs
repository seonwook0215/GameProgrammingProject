using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagaer : MonoBehaviour
{
    public static GameManagaer instance;

    //public bool isGameover = false;
    public GameObject Player;
    public GameObject Enemy;
    public GameObject gmaeoverUI;
        
    private void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("게임 매니저가 두개이상!");
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
}
