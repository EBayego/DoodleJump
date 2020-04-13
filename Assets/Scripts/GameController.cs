using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static int Score = 0;
    public string ScoreString = "Score";
    // Start is called before the first frame update

    public Text textScore;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb2d.velocity.y > 0 && transform.position.y > Score)
        {
            Score = transform.position.y;
        }

        scoreText.text = "Score: " + Mathf.Round(topScore).ToString(),

    }
}
