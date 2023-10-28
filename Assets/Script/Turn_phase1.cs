using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Turn_phase1 : MonoBehaviour //�����̶� ��
{
    public static Turn_phase1 instance;
    public float Day;
    public bool phase1;
    
    [SerializeField] TextMeshProUGUI firstphase_turn;
    [SerializeField] TextMeshProUGUI firstphase_text;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Duplicated Turn_phase1, ignoring this one");
        }
    }

    private void Start()
    {

        phase1 = false;
        Debug.Log("Phase1 start");
        
        
    }
    private void Update()
    {
        setStateText();

    }
    void setStateText()
    {
        if (phase1)
        {
            Day = TurnManager.instance.Day;
            firstphase_turn.text = Day+"  Turn";
            firstphase_text.text = "Paladin : " + PUnitManager.instance.Paladin.ToString() +
            "\nLancer : " + PUnitManager.instance.Lancer.ToString() +
            "\nArcher : " + PUnitManager.instance.Archer.ToString() +
            "\nMP : " + PResourceManager.instance.MP.ToString() +
            "\nR_B : " + PBuildingManager.instance.R_building.Count.ToString() +
            "\nP_B : " + PBuildingManager.instance.P_building.Count.ToString() +
            "\nL_B : " + PBuildingManager.instance.L_building.Count.ToString() +
            "\nA_B : " + PBuildingManager.instance.A_building.Count.ToString();
        }
        else
        {
            firstphase_text.text = "";
        }
    }
}
