using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour{

    public GameObject menu;
    public static bool juegopausado;
    public Button gyroBtn;
    public bool gyroOn;

    void init() {
        gyroOn = true;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(juegopausado == true){
                quitarpausa();
            }else{
                pausa();
            }
        }
    }

    public void pausa(){
        menu.SetActive(true);
        Time.timeScale = 0; 
        juegopausado = true;
    }

    void quitarpausa(){
        menu.SetActive(false);
        Time.timeScale = 1;
        juegopausado = false;
    }
    
    public void btncontinue(){
        menu.SetActive(false);
        Time.timeScale = 1;
        juegopausado = false;
    }
    public void btnrestart() {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("Doodle");
        if (isGyroOn())
        {
            gyroBtn.GetComponentInChildren<Text>().text = "GYRO";
        }
        else
        {
            gyroBtn.GetComponentInChildren<Text>().text = "TOUCH";
        }

    }

    public void btnmainmenu(){
        SceneManager.LoadScene("MainMenu");
    }
    
    public void gyroButton() {
        if (isGyroOn())
        {
            setGyroOn(false);
            gyroBtn.GetComponentInChildren<Text>().text = "TOUCH";
        }
        else
        {
            setGyroOn(true);
            gyroBtn.GetComponentInChildren<Text>().text = "GYRO";
        }
    }

    public void setGyroOn(bool g)
    {
        gyroOn = g;
    }

    public bool isGyroOn()
    {
        return gyroOn;
    }

}
