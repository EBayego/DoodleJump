using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public GameObject[] trashes=new GameObject[4]; 
    private GameObject current;
    private float leftLimit = -3.19f, rightLimit = 3.1f, minTime = 15.0f, maxTime = 25.0f, timer, timeNextObject, posX;
    
    void Start()
    {
        timeNextObject = Random.Range(minTime, maxTime);
        timer = 0.0f;
    }
    
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeNextObject) {
            current = trashes[Random.Range(0, trashes.Length - 1)];
            posX = Random.Range(leftLimit, rightLimit);
            this.transform.position = new Vector3(posX, this.transform.position.y, this.transform.position.z);
            Instantiate(current, this.transform.position, Quaternion.identity);
            timer = 0.0f;
        }
    }
}
