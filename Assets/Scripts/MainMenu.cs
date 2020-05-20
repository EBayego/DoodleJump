using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour{
    
    public GameObject menu;
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void btnplay() {
        SceneManager.LoadScene(1);

    }

    //public void btnsettings(){
    //}

    public void btnexit() {
        Debug.Log("SALIR");
        Application.Quit();
    }

}
