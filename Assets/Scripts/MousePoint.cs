using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoint : MonoBehaviour
{
    [SerializeField] private Camera pointCam;
    //[SerializeField] private LayerMask layerMask;

    private void Update()
    {
        
        Ray ray = pointCam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycasthit))
        {
            Debug.Log(raycasthit.transform.name);
            transform.position = raycasthit.point;
        }
    }
}
