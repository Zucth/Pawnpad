using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsTestForCutscene : MonoBehaviour
{
    private CutsceneObserverController cutsceneObserverController;

    private void Start()
    {
        //cutsceneObserverController = (CutsceneObserverController)cutsceneObserverController.GetComponent(typeof(CutsceneObserverController));
        cutsceneObserverController = (CutsceneObserverController)FindObjectOfType(typeof(CutsceneObserverController));
    }
    private void OnTriggerEnter(Collider other)
    {
        cutsceneObserverController.CutToSubCam();
    }
}
