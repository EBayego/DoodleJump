using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject platform, NewPlatform;
    public Transform generationPoint;
    private float newDistanceY, newDistanceX;
    private float height, minY, maxY;
    private static float minX = -4.5f, maxX = 4.5f;
    private int platformCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        height = platform.GetComponent<BoxCollider>().size.y;
        minY = platform.transform.position.y + height;
    }

    // Update is called once per frame
    void Update()
    {
        if (platform == null)
        {
            platform = NewPlatform;
        }
        if (transform.position.y < generationPoint.position.y + 6)
        {
            newDistanceX = Random.Range(minX, maxX);
            maxY = minY + 5.1f;
            do
            {
                newDistanceY = Random.Range(minY, maxY);
            } while (newDistanceY - minY < 2);
            minY = newDistanceY + height;
            transform.position = new Vector3(newDistanceX, newDistanceY, transform.position.z);
            NewPlatform = Instantiate(platform, transform.position, transform.rotation);
            NewPlatform.name = "Platform " + platformCounter;
            platformCounter++;
        }
    }
}
