using System.Collections;
using UnityEngine;
using Cinemachine;

public class CutsceneObserverController : Subject //aka BikeController from tutorial
{
    private CutsceneController cutsceneController;

    public CinemachineVirtualCamera vcam_1; //main cam that follow player
    public CinemachineVirtualCamera vcam_2; //cam setup with index later -> interface type is the way

    public bool subCamOn { get; private set; }

    private void Awake()
    {
        //cutsceneController = (cutsceneController)FindObjectOfType(typeof(cutsceneController));
        cutsceneController = gameObject.AddComponent<CutsceneController>();
        //cutsceneController = (CutsceneController)cutsceneController.GetComponent(typeof(CutsceneController));
    }

    private void OnEnable()
    {
        if (cutsceneController)
        {
            Attach(cutsceneController);
        }
    }

    private void OnDisable()
    {
        if (cutsceneController)
        {
            Detach(cutsceneController);
        }
    }

    public void CutToSubCam()
    {
        subCamOn = true;
        vcam_2.Priority += 2; //use give index later
        vcam_1.Priority -= 2;
        NotifyObserver();
    }
}
