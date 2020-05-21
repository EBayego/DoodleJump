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
    float timer, dirX;
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

    void Update()
    {
        velY = (float)rigidbody.velocity.y;
        //ESTO ES PARA EL MOVIMIENTO EN EL MOVIL

        dirX = Input.acceleration.x * 2;
        if (menuPause.GetComponent<MenuPause>().isGyroOn())
        {
            movement = new Vector3(dirX, velY / 18, 0);
        }
        else
        {
            if ((Input.GetTouch(0).position.x < Screen.width / 2))
            {
                while ((horizontal >= -1.0f) && ((Input.GetTouch(0).position.x < Screen.width / 2)))
                {
                    horizontal -= 0.1f;
                    Invoke("setMovement", 0.1f);
                }
            }
            else
            {
                if ((Input.GetTouch(0).position.x > Screen.width / 2))
                {
                    while ((horizontal <= 1.0f) && (Input.GetTouch(0).position.x > Screen.width / 2))
                    {
                        horizontal += 0.1f;
                        Invoke("setMovement", 0.1f);
                    }
                }
                else
                {
                    if (horizontal < 0.0f)
                    {
                        horizontal += 0.1f;
                        Invoke("setMovement", 0.1f);
                    }
                    else
                    {
                        if (horizontal > 0.0f)
                        {
                            horizontal -= 0.1f;
                            Invoke("setMovement", 0.1f);
                        }
                    }
                }
            }
            movement = new Vector3(horizontal, velY / 18, 0);
        }
        dirX = Input.acceleration.x * 2;
        if (menuPause.GetComponent<MenuPause>().isGyroOn())
        {
            movement = new Vector3(dirX, velY / 18, 0);
        }
        else
        {
            if ((Input.GetTouch(0).position.x < Screen.width / 2))
            {
                while ((horizontal >= -1.0f) && ((Input.GetTouch(0).position.x < Screen.width / 2)))
                {
                    horizontal -= 0.1f;
                    Invoke("setMovement", 0.1f);
                }
            }
            else
            {
                if ((Input.GetTouch(0).position.x > Screen.width / 2))
                {
                    while ((horizontal <= 1.0f) && (Input.GetTouch(0).position.x > Screen.width / 2))
                    {
                        horizontal += 0.1f;
                        Invoke("setMovement", 0.1f);
                    }
                }
                else
                {
                    if (horizontal < 0.0f)
                    {
                        horizontal += 0.1f;
                        Invoke("setMovement", 0.1f);
                    }
                    else
                    {
                        if (horizontal > 0.0f)
                        {
                            horizontal -= 0.1f;
                            Invoke("setMovement", 0.1f);
                        }
                    }
                }
            }
            movement = new Vector3(horizontal, velY / 18, 0);
        }

        //FIN DEL MOVIMIENTO DEL MOVIL

        //ESTO ES PARA EL MOVIMIENTO EN ORDENADOR     
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), velY / 18, 0);
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
            if (other.gameObject.GetComponent<Renderer>().material.name == "HigherPlat (Instance)" && velY <= 0)
            {
                rigidbody.velocity = new Vector3(0, speed * 1.5f, 0);
                robotAnimator.SetBool("Platform", true);
                FindObjectOfType<AudioManager>().Play("MetalJump");
            }
            else if (other.gameObject.GetComponent<Renderer>().material.name == "FakePlat (Instance)" && velY <= 0)
            {
                Destroy(other.gameObject.GetComponent<BoxCollider>());
                FadeOut(other.gameObject);
            }
            else if (other.gameObject.GetComponent<Renderer>().material.name == "OncePlat (Instance)" && velY <= 0)
            {
                Destroy(other.gameObject);
                robotAnimator.SetBool("Platform", true);
                FindObjectOfType<AudioManager>().Play("MetalJump");
                FindObjectOfType<AudioManager>().Play("PlatformBreak");
            }
            else if(velY <= 0)
            {
                rigidbody.velocity = new Vector3(0, speed, 0);
                robotAnimator.SetBool("Platform", true);
                FindObjectOfType<AudioManager>().Play("MetalJump");
            }
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

    void FadeOut(GameObject other) 
    {
        other.GetComponent<Renderer>().material.SetFloat("_Mode", 2);
        other.GetComponent<Renderer>().material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        other.GetComponent<Renderer>().material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        other.GetComponent<Renderer>().material.SetInt("_ZWrite", 0);
        other.GetComponent<Renderer>().material.DisableKeyword("_ALPHATEST_ON");
        other.GetComponent<Renderer>().material.EnableKeyword("_ALPHABLEND_ON");
        other.GetComponent<Renderer>().material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        other.GetComponent<Renderer>().material.renderQueue = 3000;
    }
}
