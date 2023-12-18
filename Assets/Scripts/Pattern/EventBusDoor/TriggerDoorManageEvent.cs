using System;
using UnityEngine;

public class TriggerDoorManageEvent : MonoBehaviour
{
    public static event Action<int> OpenDoorEvent;

    public static void StartDoorEvent(int id)
    {
        OpenDoorEvent?.Invoke(id);

    }
    private void Awake()
    {
        //Debug.Log("TriggerDoorManageEvent Detect!"); //found!
    }
}
