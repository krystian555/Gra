using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour {
    public Canvas MenuExit;
    public Button Zagraj;
    public Button Zakoncz;
    private Canvas manuUI;

    void Start()
    {
        manuUI = GetComponent<Canvas>();
        MenuExit = MenuExit.GetComponent<Canvas>(); 
        Zagraj = Zagraj.GetComponent<Button>();
        Zakoncz = Zakoncz.GetComponent<Button>();
        MenuExit.enabled = false; 
        Cursor.visible = manuUI.enabled;
        Cursor.lockState = CursorLockMode.Confined;
    }

  
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        { 
            manuUI.enabled = !manuUI.enabled;

            Cursor.visible = manuUI.enabled;

            if (manuUI.enabled)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                MenuExit.enabled = false; 
                Zagraj.enabled = true; 
                Zakoncz.enabled = true; 
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked; 
                Cursor.visible = false;
                MenuExit.enabled = false; 
            }

        }
    }

    public void PrzyciskWyjscie()
    {
        MenuExit.enabled = true; 
        Zagraj.enabled = false; 
        Zakoncz.enabled = false; 
    }

    public void PrzyciskNieWychodz()
    {
        MenuExit.enabled = false;
        Zagraj.enabled = true;
        Zakoncz.enabled = true;
    }

    public void PrzyciskStart()
    {
        manuUI.enabled = false; 
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(sceneName: "MainScene");
        
    }

    public void PrzyciskTakWyjdz()
    {
        Application.Quit(); 

    }


}
