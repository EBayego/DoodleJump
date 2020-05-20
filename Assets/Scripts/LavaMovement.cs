using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaMovement : MonoBehaviour
{
    private float speed, maxSpeed = 3.75f, temp;
    private int interval = 50, counter = 1;
    public GameObject ScoreCanvas, GameOverMenu, Player;
    private bool once;

    void Start()
    {
        speed = 1.75f;
        temp = speed;
    }

    void Update()
    {
        this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        if (speed < maxSpeed)
        {
            if (ScoreController.Score > interval * counter)
            {
                speed += 0.5f;
                temp = speed;
                counter++;
            }
        }
        if (ScoreController.Score % (interval * 3) == 0 && ScoreController.Score != 0)
        {
            if (once)
            {
                FindObjectOfType<AudioManager>().Play("LevelUp");
                Time.timeScale += 0.1f;
                speed /= Time.timeScale;
                once = false;
            }
        }
        else once = true;

        if (Player.transform.position.y - this.transform.position.y > 60)
        {
            if (Player.transform.position.y - this.transform.position.y > 40)
            {
                speed = 6f;
            }
        }

        if (Player.transform.position.y - this.transform.position.y <= 40)
        {
            speed = temp;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("RobotExplosion");
            FindObjectOfType<AudioManager>().Stop("MainTheme");
            Invoke("GameOver", 2.0f);
        }
    }

    public void GameOver()
    {
        ScoreCanvas.SetActive(false);
        GameOverMenu.SetActive(true);
        speed = 0.0f;
    }

    private void OnBecameVisible()
    {
        FindObjectOfType<AudioManager>().Play("Lava");
    }

    private void OnBecameInvisible()
    {
        FindObjectOfType<AudioManager>().Stop("Lava");
    }
}
