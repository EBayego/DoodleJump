using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject wall, newWall;
    public Transform generationPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.transform.position.y < generationPoint.position.y + 10) {
            this.transform.position += new Vector3(0.0f, 9.0f, 0.0f);
            newWall = Instantiate(wall, transform.position, transform.rotation);
        
        }   
    }
}
