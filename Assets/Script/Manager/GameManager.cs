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

    private void Awake()
    {
        if (instance == null)
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

    // Update is called once per frame
    void Update()
    {
        
        //if (Player.GetComponent<Life>().amount <= 0) //Player lose
        //{

        //}
        //else if (Enemy.GetComponent<Life>().amount <= 0) //Enemy lose
        //{

        //}
    }


}
