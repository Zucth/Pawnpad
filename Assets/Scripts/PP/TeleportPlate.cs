using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlate : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    //[SerializeField] private GameObject In_TPGateWay;
    //[SerializeField] private GameObject Out_TPGate;

    public GameManagerS1 gameManagerS1;
    private float checkForPlateScore; //plate score rn

    public GameObject Selected_Pressure_Plate; //the target pressure plate [In] visual
    //public GameObject Above_Selected_Pressure_Plate_2; //the target pressure plate [Out]
    public GameObject Selected_Pressure_Plate_2; //for visual [out]
    private bool SetToON = false;

    private void Awake()
    {
        VisualSetup();
    }
    private void VisualSetup()
    {
        if (SetToON == false)
        {
            Selected_Pressure_Plate.GetComponent<MeshRenderer>().material.color = Color.gray;
            Selected_Pressure_Plate_2.GetComponent<MeshRenderer>().material.color = Color.black;
        }
        if (SetToON == true)
        {
            Selected_Pressure_Plate.GetComponent<MeshRenderer>().material.color = Color.green;
            Selected_Pressure_Plate_2.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
    private float UseTP() //4,2,1 or just do 0,2,1
    {
        SetToON = true;
        checkForPlateScore = 0; // reset
        checkForPlateScore += 10; //+10
        VisualSetup();

        gameManagerS1.overallPlateScore += checkForPlateScore;
        return gameManagerS1.overallPlateScore;
    }

    private void OnCollisionEnter(Collision collisionCheck)
    {
        if (collisionCheck.collider.tag == "Player" && SetToON == false && Selected_Pressure_Plate_2 != false) 
        {
            UseTP();
            Player.transform.position = Selected_Pressure_Plate_2.transform.position; //Above_Selected_Pressure_Plate_2.transform.position;
        }
    }
}
