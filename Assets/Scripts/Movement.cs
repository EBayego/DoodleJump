using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Rigidbody rigidbody;
    static float speed;
    float velY = 0;
    public Animator robotAnimator;
    float timer;
    float horizontal = 0.0f;
    public GameObject ScoreCanvas, GameOverMenu;
    Vector3 movement;
    public GameObject menuPause;
    public Material[] materials = new Material[4];

    // Start is called before the first frame update
    void Start()
    {
        ScoreController.setZero();
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //para que no se suspenda el telefono mientras jugamos
        Time.timeScale = 1.0f;
        speed = 9.0f;
    }

    // Update is called once per frame
    void Update()
    {
        velY = (float)rigidbody.velocity.y;
        //ESTO ES PARA EL MOVIMIENTO EN EL MOVIL

        //dirX = Input.acceleration.x * 2;
        //if (menuPause.GetComponent<MenuPause>().isGyroOn())
        //{
        //    movement = new Vector3(dirX, velY / 18, 0);

        //}
        //else
        //{

        //    if ((Input.GetTouch(0).position.x < Screen.width / 2))
        //    {
        //        while ((horizontal >= -1.0f) && ((Input.GetTouch(0).position.x < Screen.width / 2)))
        //        {
        //            horizontal -= 0.1f;
        //            Invoke("setMovement", 0.1f);
        //        }

        //    }
        //    else
        //    {
        //        if ((Input.GetTouch(0).position.x > Screen.width / 2))
        //        {
        //            while ((horizontal <= 1.0f) && (Input.GetTouch(0).position.x > Screen.width / 2))
        //            {
        //                horizontal += 0.1f;
        //                Invoke("setMovement", 0.1f);
        //            }

        //        }
        //        else
        //        {
        //            if (horizontal < 0.0f)
        //            {
        //                horizontal += 0.1f;
        //                Invoke("setMovement", 0.1f);
        //            }
        //            else
        //            {
        //                if (horizontal > 0.0f)
        //                {
        //                    horizontal -= 0.1f;
        //                    Invoke("setMovement", 0.1f);
        //                }
        //            }
        //        }
        //    }
        //    movement = new Vector3(horizontal, velY / 18, 0);


        //}
        //dirX = Input.acceleration.x * 2;
        //if (menuPause.GetComponent<MenuPause>().isGyroOn())
        //{
        //    movement = new Vector3(dirX, velY / 18, 0);

        //}
        //else
        //{

        //    if ((Input.GetTouch(0).position.x < Screen.width / 2))
        //    {
        //        while ((horizontal >= -1.0f) && ((Input.GetTouch(0).position.x < Screen.width / 2)))
        //        {
        //            horizontal -= 0.1f;
        //            Invoke("setMovement", 0.1f);
        //        }

        //    }
        //    else
        //    {
        //        if ((Input.GetTouch(0).position.x > Screen.width / 2))
        //        {
        //            while ((horizontal <= 1.0f) && (Input.GetTouch(0).position.x > Screen.width / 2))
        //            {
        //                horizontal += 0.1f;
        //                Invoke("setMovement", 0.1f);
        //            }

        //        }
        //        else
        //        {
        //            if (horizontal < 0.0f)
        //            {
        //                horizontal += 0.1f;
        //                Invoke("setMovement", 0.1f);
        //            }
        //            else
        //            {
        //                if (horizontal > 0.0f)
        //                {
        //                    horizontal -= 0.1f;
        //                    Invoke("setMovement", 0.1f);
        //                }
        //            }
        //        }
        //    }
        //    movement = new Vector3(horizontal, velY / 18, 0);


        //}

        //FIN DEL MOVIMIENTO DEL MOVIL

        //ESTO ES PARA EL MOVIMIENTO EN ORDENADOR     
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), velY / 18, 0);
        //FIN DEL MOVIMIENTO DEL ORDENADOR

        this.transform.position += movement * speed * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            robotAnimator.SetBool("Platform", false);
            timer = 0.0f;
        }
        if (this.transform.position.x <= (-4.5f))
        {
            this.transform.position = new Vector3(4.4f, transform.position.y, 0);
        }
        if (this.transform.position.x >= 4.5f)
        {
            this.transform.position = new Vector3((-4.4f), transform.position.y, 0);
        }
    }

    public void setMovement()
    {
        movement = new Vector3(horizontal, velY / 18, 0);
    }

    void OnCollisionEnter(Collision other) //FUNCION PARA QUE REBOTE EL PERSONAJE
    {
        if (other.gameObject.tag == "Platform")
        {
            if (other.gameObject.GetComponent<Renderer>().material.name == "HigherPlat (Instance)" && velY < 0)
            {
                Debug.Log("gordo");
                rigidbody.velocity = new Vector3(0, speed * 3, 0);
            }
            else
            {
                Debug.Log("no");
                rigidbody.velocity = new Vector3(0, speed, 0);
            }
            robotAnimator.SetBool("Platform", true);
            FindObjectOfType<AudioManager>().Play("MetalJump");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            this.gameObject.SetActive(false);
            ScoreCanvas.SetActive(false);
            GameOverMenu.SetActive(true);
        }
    }

    public static float getSpeed()
    {
        return speed;
    }
}
