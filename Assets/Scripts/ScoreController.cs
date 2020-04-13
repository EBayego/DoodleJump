using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour
{

    public static float Score = 0;
    public string ScoreString = "Score";
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
            Score = transform.position.y;
        }

        textScore.text = "Score: " + Mathf.Round(Score).ToString();

    }
}
