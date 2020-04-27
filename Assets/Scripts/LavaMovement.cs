using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaMovement : MonoBehaviour
{
    private float speed = 2.25f, maxSpeed = 3.75f;
    private int interval = 50, counter = 1;
    public GameObject ScoreCanvas, GameOverMenu;
    void Update()
    {
        this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        if (speed < maxSpeed)
        {
            if (ScoreController.Score > interval * counter)
            {
                speed += 0.5f;
                counter++;
            }
        }
        if (ScoreController.Score % (interval*3) == 0 && ScoreController.Score!=0)
        {
            Time.timeScale += 0.1f;
            speed /= Time.timeScale;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SetActive(false);
            Invoke("GameOver", 2.0f);
        }
    }

    void GameOver()
    {
        ScoreCanvas.SetActive(false);
        GameOverMenu.SetActive(true);
        speed = 0.0f;
    }
}
