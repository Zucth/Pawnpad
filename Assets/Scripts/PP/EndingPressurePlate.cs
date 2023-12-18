using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPressurePlate : MonoBehaviour
{
    //private bool StateBool;

    public GameObject Selected_Pressure_Plate; //the target pressure plate
    public GameObject EndingUI_byWiningCondition;
    private void Start()
    {
        //Selected_Pressure_Plate.SetActive(false);
    }
    private void BringupUI()
    {
        EndingUI_byWiningCondition.SetActive(true);
    }
    private void VisualSetup() //active on awake
    {
        Selected_Pressure_Plate.GetComponent<MeshRenderer>().material.color = Color.magenta;
    }
    private void OnCollisionEnter(Collision collisionCheck)
    {
        if (collisionCheck.collider.tag == "Player")
        {
            BringupUI();
            VisualSetup();
        }
    }
}     

