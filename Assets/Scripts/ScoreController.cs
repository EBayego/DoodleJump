using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour
{

    public static int Score = 0;
    // Start is called before the first frame update

    public Text textScore;
    public Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.y > 0 && transform.position.y > Score)
        {
            Score = (int) transform.position.y;
        }

        textScore.text = "Score: " + Score;

    }

    public static void setZero()
    {
        Score = 0;
    }
}
