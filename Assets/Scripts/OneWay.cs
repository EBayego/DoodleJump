using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWay : MonoBehaviour
{
    //the collider of the main visible platform
    public BoxCollider collider;
    bool oneway;

    void Update()
    {
        if (oneway)
            collider.enabled = false;
        if (!oneway)
            collider.enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        oneway = true;
    }

    private void OnTriggerExit(Collider other)
    {
        oneway = false;
    }
}
