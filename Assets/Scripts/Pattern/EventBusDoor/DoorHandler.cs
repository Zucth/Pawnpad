using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public bool open = false;
    public bool isOpened = false;
    public int doorId;

    [SerializeField] private Animator m_Animator;
    //[SerializeField] private string PushDoorOpen = "PushDoorOpen";
    //[SerializeField] private string PushDoorClose = "PushDoorClose";
    //private bool m_door;

    private void Start()
    {
        //m_door = true;
        m_Animator = GetComponent<Animator>();
        //m_Animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        TriggerDoorManageEvent.OpenDoorEvent += Opendoor;
    }
    private void OnDisable()
    {
        TriggerDoorManageEvent.OpenDoorEvent -= Opendoor;
    }
    void Opendoor(int triggerID) //check door id
    {
        if (triggerID == doorId)
        {
            open = true;
        }
    }
    private void Update() //activate door animation
    {


            if(isOpened == true && open == true)
            {
                isOpened = false;
                //m_Animator.Play("PushDoorOpen", 0, 0.0f);
                m_Animator.SetBool("PushDoorClose", true);
                //m_Animator.SetBool("PushDoorIdle", false);
                m_Animator.SetBool("PushDoorOpen", false);
            }
            if (isOpened == false && open == true)
            {
                isOpened = true;
            //m_Animator.Play("PushDoorClose", 0, 0.0f);
            //m_Animator.SetBool("PushDoorIdle", false);
            m_Animator.SetBool("PushDoorClose", false);
            m_Animator.SetBool("PushDoorOpen", true);
                
            }
            /*
            else
            {
                m_Animator.SetBool("PushDoorOpen", false);
                //m_Animator.SetBool("PushDoorIdle", true);
                m_Animator.SetBool("PushDoorClose", false);
            }
            */
            

            //Debug.Log("Door detect!");

            /*
            isOpened = true;
            transform.position += Vector3.up * 5f;
            */
        
    }
    private void Awake()
    {
        // Debug.Log("DoorHandler Detect!"); //found!
    }
}
