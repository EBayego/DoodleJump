using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject platform, NewPlatform;
    public Material[] materials = new Material[4]; //70% normal, 10% resto
    Renderer render;
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
            maxY = minY + 2.3f;
            do
            {
                newDistanceY = Random.Range(minY, maxY);
            } while (newDistanceY - minY < 1);
            minY = newDistanceY + height;
            transform.position = new Vector3(newDistanceX, newDistanceY, transform.position.z);
            NewPlatform = Instantiate(platform, transform.position, transform.rotation);
            NewPlatform.name = "Platform " + platformCounter;
            render = NewPlatform.GetComponent<Renderer>();
            render.enabled = true;
            chooseMaterial();
            platformCounter++;
        }
    }

    private void chooseMaterial()
    {
        int numMat = Random.Range(0, 100);
        if (numMat <= 70) //normal
        {
            render.sharedMaterial = materials[0];
        }
        else if (numMat > 70 && numMat <= 80) //fake
        {
            render.sharedMaterial = materials[1];
        }
        else if (numMat > 80 && numMat <= 90) //once
        {
            render.sharedMaterial = materials[2];
        }
        else if (numMat > 90 && numMat <= 100) //higher
        {
            render.sharedMaterial = materials[3];
        }
    }
}