using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Pared") {
            Destroy(other.gameObject);
        }
    }
}
