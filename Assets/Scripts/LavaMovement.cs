using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaMovement : MonoBehaviour
{
    private float speed = 1f;
    private int interval = 50, counter = 1;

    void Update()
    {
        this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        if (speed < 3.5f)
        {
            if (ScoreController.Score > interval * counter)
            {
                if(counter % 2 == 0)
                {
                    Time.timeScale += 0.1f;
                }
                speed += 0.5f;
                speed /= Time.timeScale;
                counter++;
            }
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
        SceneManager.LoadScene("MainMenu");
    }
}
