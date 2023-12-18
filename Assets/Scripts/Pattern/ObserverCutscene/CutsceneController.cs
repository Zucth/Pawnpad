using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CutsceneController : Observer //aka HUDController or any other that recieve. from tutorial
{
    private CutsceneObserverController cutsceneObserverController;

    private CinemachineVirtualCamera Vcam_1;
    private CinemachineVirtualCamera Vcam_2;

    private bool subccamOn;

    public void Update()
    {
        ResetCam();
    }

    IEnumerator loadCamAfterDelay(float waitforSecs) //for cam setup
    {
        yield return new WaitForSeconds(waitforSecs);
        Vcam_1.Priority = 10;
        Vcam_2.Priority -= 2;
    }

    public void ResetCam()
    {
        if(subccamOn == true)
        {
            subccamOn = false;
            StartCoroutine(loadCamAfterDelay(5));
        }
        if(subccamOn == false)
        {
            //do nothing
        }
        
    }

    public override void Notify(Subject subject)
    {
        if (!cutsceneObserverController)
        {
            cutsceneObserverController = subject.GetComponent<CutsceneObserverController>();
        }
        if (cutsceneObserverController)
        {
            Vcam_1 = cutsceneObserverController.vcam_1;
            Vcam_2 = cutsceneObserverController.vcam_2;
            subccamOn = cutsceneObserverController.subCamOn;

        }
    }
}
