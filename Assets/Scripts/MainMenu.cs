using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("Doodle");
    }

    //public void btnsettings(){
    //}

    public void btnexit() {
        Application.Quit();
    }

}
