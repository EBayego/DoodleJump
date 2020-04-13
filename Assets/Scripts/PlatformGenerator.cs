using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject platform;
    public Transform generationPoint;
    private float newDistanceY, newDistanceX;
    private float height, minY, maxY;
    private static float minX = -4.7f, maxX = 4.7f;

    // Start is called before the first frame update
    void Start()
    {
        minY = platform.transform.position.y + height;
        height = platform.GetComponent<BoxCollider>().size.y;  
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < generationPoint.position.y + 6)
        {
            newDistanceX = Random.Range(minX, maxX);
            maxY = minY + 5.5f;
        do
        {
            newDistanceY = Random.Range(minY, maxY);
        } while (newDistanceY - minY < 2);
        minY = newDistanceY + height;
            transform.position = new Vector3(newDistanceX, newDistanceY, transform.position.z);
            Instantiate(platform, transform.position, transform.rotation);
        }
    }
}
