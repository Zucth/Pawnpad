using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class _SceneManager : MonoBehaviour
{
    IEnumerator loadSceneAfterDelay(float waitBySecs) //for scene setup
    {
        yield return new WaitForSeconds(waitBySecs);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void forScene()
    {
        StartCoroutine(loadSceneAfterDelay(8));
    }

    ///////////////////////////////    use for switch player-statue later on (with state pattern maybe?)   ////////////////////////////////////

    /*   
    public GameObject tPlayer;
    public Transform tFollowTarget;
    private CinemachineVirtualCamera vcam;

    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if (tPlayer == null)
        {
            tPlayer = GameObject.FindWithTag("Player");
        }
        tFollowTarget = tPlayer.transform;
        vcam.LookAt = tFollowTarget;
        vcam.Follow = tFollowTarget;
    }
    */
}
