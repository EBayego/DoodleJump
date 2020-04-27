using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour{

    public Rigidbody rigidbody;
    float speed=9.0f;
    float velY = 0, velX = 0;
    public Animator robotAnimator;
    float timer;
    float dirX;
    public GameObject ScoreCanvas, GameOverMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        ScoreController.setZero();
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //para que no se suspenda el telefono mientras jugamos
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    { 
        velY = (float)rigidbody.velocity.y;
        //ESTO ES PARA EL MOVIMIENTO EN EL MOVIL
        dirX = Input.acceleration.x*2;

        //Vector3 Movement = new Vector3(dirX, velY/18, 0);
        //FIN DEL MOVIMIENTO DEL MOVIL

        //ESTO ES PARA EL MOVIMIENTO EN ORDENADOR     
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), velY/18, 0);
        this.transform.position += Movement * speed * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > 0.5f) {
            robotAnimator.SetBool("Platform", false);
            timer = 0.0f;
        }
        if (this.transform.position.x <= (-4.5f)) {
            this.transform.position = new Vector3(4.4f,transform.position.y,0);
        }
        if (this.transform.position.x >= 4.5f)
        {
            this.transform.position = new Vector3((-4.4f), transform.position.y, 0);
        }
    }

    void OnCollisionEnter(Collision other) //FUNCION PARA QUE REBOTE EL PERSONAJE
    {
        velX = (float)rigidbody.velocity.x;
        if (other.gameObject.tag == "Platform") 
        {
            robotAnimator.SetBool("Platform", true);
            FindObjectOfType<AudioManager>().Play("MetalJump");
            rigidbody.velocity = new Vector3(0, speed, 0);
        }
        
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 8)
        {
            this.gameObject.SetActive(false);
            ScoreCanvas.SetActive(false);
            GameOverMenu.SetActive(true);

        }
    }
 
}
