using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 distance = new Vector3(0, 1, -12);
    // Start is called before the first frame update
    private void LateUpdate()
    {
        transform.position = new Vector3(0, target.position.y + distance.y, target.position.z + distance.z);
    }
}
