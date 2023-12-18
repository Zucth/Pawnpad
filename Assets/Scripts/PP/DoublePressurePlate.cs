using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePressurePlate : MonoBehaviour
{
    public GameManagerS1 gameManagerS1;

    //check for pressure plate state
    //no step zero but as so you know 0 mean haven't ever step on
    [SerializeField] [Tooltip("never step on [preview state] - remember to flick only one state")] protected bool State0 = true; //never before
    [SerializeField] [Tooltip("first time after step on")] protected bool State1 = false; //1st time
    [SerializeField] [Tooltip("second time after step on")] protected bool State2 = false; //2nd time 
    [SerializeField] [Tooltip("third time after step on")] protected bool State3 = false; //3rd time 

    private float checkForRound = 1; //use this to check round instead of using boolean
    private float checkForPlateScore; //plate score rn

    public GameObject Selected_Pressure_Plate; //the target pressure plate

    private void Awake()
    {
        VisualSetup();
    }

     protected void VisualSetup()
    {
        if (State0)
        {
            Selected_Pressure_Plate.GetComponent<MeshRenderer>().material.color = Color.white;
            checkForRound = 0;
        }
        if (State1)
        {
            Selected_Pressure_Plate.GetComponent<MeshRenderer>().material.color = Color.yellow;
            checkForRound = 1;
        }
        if (State2)
        {
            Selected_Pressure_Plate.GetComponent<MeshRenderer>().material.color = Color.green; //choose color later on
            checkForRound = 2;
        }
        if (State3)
        {
            Selected_Pressure_Plate.GetComponent<MeshRenderer>().material.color = Color.red; //choose color later on
            checkForRound = 3;
        }
    }

    private float firstTimeStepOn() //4,2,1 or just do 0,2,1
    {
        checkForPlateScore = 0; // reset
        checkForPlateScore += 4; //+4
        State0 = false;
        State1 = true;
        VisualSetup();

        gameManagerS1.overallPlateScore += checkForPlateScore;
        return gameManagerS1.overallPlateScore;
    }
    private float secondTimeStepOn()
    {
        checkForPlateScore = 0; // reset
        checkForPlateScore +=2; //+2
        State1 = false;
        State2 = true;
        VisualSetup();

        gameManagerS1.overallPlateScore += checkForPlateScore;
        return gameManagerS1.overallPlateScore;
    }
    private float thirdTimeStepOn()
    {
        
        checkForPlateScore = 0; // reset
        checkForPlateScore++; //set to 1 to make the level incomplete
        State2 = false;
        State3 = true;
        VisualSetup();

        gameManagerS1.overallPlateScore += checkForPlateScore;
        return gameManagerS1.overallPlateScore;
    }


    private void OnCollisionEnter(Collision collisionCheck)
    {
        if(collisionCheck.collider.tag == "Player" && checkForRound == 0) 
        {
            firstTimeStepOn(); //do the first time setup for secondtime
            VisualSetup();
        }

        if (collisionCheck.collider.tag == "Player" && checkForRound == 2) // 0, 2, 4, 5, 6, 7...
        {
            secondTimeStepOn(); //do the second time setup for thirdtime
            VisualSetup();
        }

        if (collisionCheck.collider.tag == "Player" && checkForRound == 3) //0,2,3,4,5
        {
            thirdTimeStepOn(); //do the third time setup for last state
            VisualSetup();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        checkForRound++;
        //Debug.Log(checkForRound);
    }
}
