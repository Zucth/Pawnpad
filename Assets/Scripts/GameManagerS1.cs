using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManagerS1 : MonoBehaviour
{
    [SerializeField] private UnityEvent DotheEvent;
    [SerializeField] private UnityEvent ReverttheEvent;

    [SerializeField] [Tooltip("This must be the sum up number of all plate the player have to step on")] private float finishValue; //
    private bool scoreRight = true;

    public float overallPlateScore;
    //private float OddNumber;

    private void Update()
    {
        CheckForHighKeyUnlocked();
    }

    private void CheckForHighKeyUnlocked()
    {
        if (overallPlateScore == finishValue && scoreRight == true)
        {
            //do the event
            DotheEvent.Invoke(); //when to activate the event
        }

        if(overallPlateScore %2 != 0) // overallplatescore /2 && != 0 check for odd number
        {
            scoreRight = false;
            Debug.Log("This is an odd number, you are game over");
        }

        if(scoreRight == false)
        {
            ReverttheEvent.Invoke();
        }
    }
}
