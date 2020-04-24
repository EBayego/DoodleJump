using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameOver : MonoBehaviour
{
    public Text score, scoreFinal;

    void OnEnable()
    {
        scoreFinal.text = score.text;
    }

    public void Restart() {
        SceneManager.LoadScene("Doodle");
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
