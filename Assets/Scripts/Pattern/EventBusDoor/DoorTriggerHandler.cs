using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerHandler : MonoBehaviour
{
    public int triggerID;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        TriggerDoorManageEvent.StartDoorEvent(triggerID);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        TriggerDoorManageEvent.StartDoorEvent(triggerID);
    }

    /*
    private void OnGUI()
    {
        if (GUI.Button(new Rect(50, 50, 50, 200), "Door turn"))
        {
            TriggerDoorManageEvent.StartDoorEvent(triggerID);
        }
    } */

    private void Awake()
    {
        //Debug.Log("DoorTriggerHandler Detect!"); //found!
    }
}
