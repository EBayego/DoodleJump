using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OneWay")
        {
            platform = other.gameObject.transform.parent.gameObject;
            //Destroy(other.gameObject.transform.parent.gameObject);
            Invoke("DestroyObj", 0.7f);
        }
    }

    void DestroyObj()
    {
        Destroy(platform);
    }
}
