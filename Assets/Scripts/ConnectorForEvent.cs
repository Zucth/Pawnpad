using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorForEvent : MonoBehaviour
{
    [Tooltip("Ending_PP")] public GameObject ChoosengameObject; 
    private void Start()
    {
        //Debug.Log("Hello World");
        ChoosengameObject = GameObject.FindGameObjectWithTag("EC"); //attach script to this game object
        ChoosengameObject.SetActive(false);
        //ChoosengameObject.AddComponent<EndingPressurePlate>();
    }
    public void TestforEventUse() //test case
    {
        Debug.Log("TestforEventUse is working just fine");
    }

    public void SetEndingPlateActive()
    {
        Debug.Log("SetEndingPlateActive is working");
        //ChoosengameObject = GameObject.FindObjectsOfType(typeof(EndingPressurePlate));
        //ChoosengameObject = GameObject.Find("PPEnding");

        ChoosengameObject.SetActive(true);
    }
    public void SetThingInactive()
    {
        Debug.Log("SetThingInactive is working");
        ChoosengameObject.SetActive(false);
    }
}
