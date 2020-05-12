using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningAlert : MonoBehaviour
{
    public void Start()
    {
        //StartCoroutine(SpriteFadeOut(GetComponent<SpriteRenderer>()));
        //StartCoroutine(SpriteFadeIn(GetComponent<SpriteRenderer>()));

        for (int i = 0; i < 10; i++)
        {
            Invoke("inn", 1f);
            Invoke("outt", 1f);
            Debug.Log("tonto");
        }
    }

    IEnumerator SpriteFadeOut(SpriteRenderer sprenderer)
    {
        Color c = sprenderer.color;
        while (c.a > 0f)
        {
            c.a -= Time.deltaTime / 1.2f; // fadeOutTime
            sprenderer.color = c;
            if (c.a <= 0f)
                c.a = 0.0f;
            yield return null;
        }
        sprenderer.color = c;
    }

    IEnumerator SpriteFadeIn(SpriteRenderer sprenderer)
    {
        Color c = sprenderer.color;
        while (c.a < 1f)
        {
            c.a += Time.deltaTime / 1.2f; // fadeOutTime
            sprenderer.color = c;
            if (c.a >= 1f)
                c.a = 1.0f;
            yield return null;
        }
        sprenderer.color = c;
    }

    void inn()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }

    void outt()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
