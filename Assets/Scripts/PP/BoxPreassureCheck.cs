using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPreassureCheck : MonoBehaviour
{
    public GameManagerS1 gameManagerS1;

    private float checkForPlateScore; //plate score rn
    private bool SetToON = false;

    public GameObject Selected_Pressure_Plate; //the target pressure plate
    private void Awake()
    {
        VisualSetup();
    }
    private void VisualSetup()
    {
        if (SetToON == false)
        {
            Selected_Pressure_Plate.GetComponent<MeshRenderer>().material.color = Color.cyan;
        }
        if (SetToON == true)
        {
            Selected_Pressure_Plate.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        
    }

    private float CheckforBoxOnPP() //4,2,1 or just do 0,2,1
    {
        checkForPlateScore = 0; // reset
        checkForPlateScore += 6; //+6
        VisualSetup();

        gameManagerS1.overallPlateScore += checkForPlateScore;
        return gameManagerS1.overallPlateScore;
    }

    private float CheckforBoxOnPPEqualFalse()
    {
        checkForPlateScore = 0; // reset
        checkForPlateScore -= 6; //+6
        VisualSetup();

        gameManagerS1.overallPlateScore += checkForPlateScore;
        return gameManagerS1.overallPlateScore;
    }

    private void OnCollisionEnter(Collision collisionCheck)
    {
        if (collisionCheck.collider.tag == "Box")
        {
            SetToON = true;
            VisualSetup();
            CheckforBoxOnPP();
        }
    }
    private void OnCollisionExit(Collision collisionCheck)
    {
        if (collisionCheck.collider.tag == "Box")
        {
            SetToON = false;
            VisualSetup();
            CheckforBoxOnPPEqualFalse();
        }
    }
}
