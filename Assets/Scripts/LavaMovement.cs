using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaMovement : MonoBehaviour
{
    public float speed = 0.5f;
    private int interval = 50, counter = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        if (speed < 3.5f)
        {
            if (ScoreController.Score > interval*counter)
            {         
            speed += 0.5f;
            counter++;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
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
