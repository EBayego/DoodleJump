using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningAlert : MonoBehaviour
{
    bool visible;
    static bool posChanged = false;
    private static int count = 4;
    static Vector3 pos;

    private void Start()
    {
        outt();
        pos = transform.position;
    }

    private void Update()
    {
        if (visible && count <= 3)
            Invoke("outt", 0.2f);
        if (!visible && count <= 3)
            Invoke("inn", 0.2f);
        if (posChanged)
        {
            transform.position = pos;
            posChanged = false;
        }
    }

    void inn()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        visible = true;
        count++;
    }

    void outt()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        visible = false;
    }

    public static void startAlert(float posX)
    {
        pos.x = posX;
        count = 0;
        posChanged = true;
    }
}
