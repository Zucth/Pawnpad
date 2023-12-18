using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BTNconnector : MonoBehaviour
{
    //this code file will be use for UI connector only. 
    public bool IsThisFirstMenu;
    public bool IsThisInGameMenu;
    public bool PauseIsOn;
    public bool IsTutorialNeed;
    //public bool SwitchCam = false;

    public GameObject MainMenu_UI; //first menu scene
    public GameObject Option_UI; //option in the first menu scene

    public GameObject LS_W1_UI; //w1
    public GameObject LS_W2_UI; //w2
    public GameObject LS_W3_UI; //w3

    public GameObject _Pause_UI; //pause in game scene
    //public GameObject _Win_UI; //UI tutorial -> got call from PPEnding anyway
    public GameObject _Tutorial_UI; //UI tutorial

    public AudioSource btnSound;
    //public GameObject GoOfBTNSound;

    private CutsceneObserverController cutsceneObserverController;

   // private IEnumerator coroutine;

    private void Awake()
    {

        
        
        btnSound = GameObject.FindGameObjectWithTag("btn_tag").GetComponent<AudioSource>();
            //GoOfBTNSound.GetComponent<BTNconnector>
            //btnSound = GameObject.FindGameObjectWithTag("btn_tag");
            //btnSound.gameObject.CompareTag("btn_tag");
        

        //cutsceneObserverController = GetComponent<CutsceneObserverController>();
        cutsceneObserverController = (CutsceneObserverController)FindObjectOfType(typeof(CutsceneObserverController));

        if (IsThisInGameMenu)
        {
            if (IsTutorialNeed)
            {
                _Tutorial_UI.SetActive(true);
            }
        }
        
    }

    private void Update()
    {
        /*
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Hello");
        } */

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsThisFirstMenu == true) //UI set for Menu
            {
                btnSound.Play();
                Option_UI.SetActive(false);
                LS_W1_UI.SetActive(false);
                LS_W2_UI.SetActive(false);
                LS_W3_UI.SetActive(false);
                MainMenu_UI.SetActive(true);
            }
            if (IsThisInGameMenu == true) //UI setting for any in game scene
            {
                if (PauseIsOn == true && IsTutorialNeed == false)
                {
                    btnSound.Play();
                    Debug.Log("Choice_On" + PauseIsOn);
                    OnPause_UI();
                    //coroutine = WaitandActivate(2);
                    //PauseIsOn = true;
                    if (PauseIsOn) PauseIsOn = false;
                    else PauseIsOn = true;
                }
                else if (PauseIsOn == false && IsTutorialNeed == false)
                {
                    btnSound.Play();
                    Debug.Log("Choice_Off" + PauseIsOn);
                    OffPause_UI();
                    //coroutine = WaitandActivate(2);
                    //PauseIsOn = false;
                    if (PauseIsOn) PauseIsOn = false;
                    else PauseIsOn = true;
                }
                if (IsTutorialNeed == true) //ui divide used in those scene
                {
                    _Tutorial_UI.SetActive(false);
                    IsTutorialNeed = false;
                }
            }
            else
                Debug.Log("You have forgot to tick one of the menu condition as true");
        }

        if(Input.GetMouseButtonDown(1))
        {
            //Debug.Log("This is working"); // working just fine
            if (IsThisInGameMenu == true)
            {
                //Debug.Log("This is working");
                cutsceneObserverController.CutToSubCam();
            }
        }
            
    }
    public void LoadSameScene() //restart condition
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        btnSound.Play();
    }
    public void LoadNextScene() //load next scene
    {
        btnSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadOptionUI() //option
    {
        btnSound.Play();
        MainMenu_UI.SetActive(false);
        Option_UI.SetActive(true);
    }
    public void QuitApplication() //exit
    {
        btnSound.Play();
        Application.Quit();
    }
    public void LoadWorldSelecting1() //w1 (from start btn or other world btn)
    {
        btnSound.Play();
        MainMenu_UI.SetActive(false);
        LS_W1_UI.SetActive(true);
        LS_W2_UI.SetActive(false);
        LS_W3_UI.SetActive(false);
    }
    public void LoadWorldSelecting2() //w2
    {
        btnSound.Play();
        LS_W1_UI.SetActive(false);
        LS_W2_UI.SetActive(true);
        LS_W3_UI.SetActive(false);
    }
    public void LoadWorldSelecting3() //w3
    {
        btnSound.Play();
        LS_W1_UI.SetActive(false);
        LS_W2_UI.SetActive(false);
        LS_W3_UI.SetActive(true);
    }
    public void OnPause_UI()
    {
        btnSound.Play();
        _Pause_UI.SetActive(false);
    }
    public void OffPause_UI()
    {
        btnSound.Play();
        _Pause_UI.SetActive(true);
    }
    /*
    public IEnumerator WaitandActivate(float DelayTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(DelayTime);
            if (PauseIsOn) PauseIsOn = false;
            else PauseIsOn = true;
            print("PauseIsOn_Boolean_Check" + PauseIsOn);
        }
    }
    */
    public void LoadBackToMainMenu() //quit (quit in game will always sent back to FirstMenu)
    {
        btnSound.Play();
        SceneManager.LoadScene("TitleScene");
    }
    public void LoadTutorialUI()
    {
        btnSound.Play();
        _Tutorial_UI.SetActive(true);
    }
    public void LoadScene1()
    {
        btnSound.Play();
        SceneManager.LoadScene("Stage01");
    }
    public void LoadScene2()
    {
        btnSound.Play();
        SceneManager.LoadScene("Stage02");
    }
    public void LoadScene3()
    {
        btnSound.Play();
        SceneManager.LoadScene("Stage03");
    }
    public void LoadScene4()
    {
        btnSound.Play();
        SceneManager.LoadScene("Stage04");
    }
    public void LoadScene5()
    {
        btnSound.Play();
        SceneManager.LoadScene("Stage05");
    }
    public void LoadScene6()
    {
        btnSound.Play();
        SceneManager.LoadScene("Stage06");
    }
    public void LoadScene7()
    {
        btnSound.Play();
        SceneManager.LoadScene("Stage07");
    }
    public void LoadScene8()
    {
        btnSound.Play();
        SceneManager.LoadScene("Stage08");
    }
    public void LoadScene9()
    {
        btnSound.Play();
        SceneManager.LoadScene("Stage09");
    }
    public void LoadScene10()
    {
        btnSound.Play();
        SceneManager.LoadScene("Stage10");
    }
    public void LoadScene11()
    {
        btnSound.Play();
        SceneManager.LoadScene("Stage11");
    }
    public void LoadScene12()
    {
        btnSound.Play();
        SceneManager.LoadScene("Stage12");
    }
}
