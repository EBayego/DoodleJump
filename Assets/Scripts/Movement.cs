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
    
    // Start is called before the first frame update
    void Start(){ // ESTO ES COMO EL INIT DE LOS APPLETS
   
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //para que no se suspenda el telefono mientras jugamos

        

    }

    // Update is called once per frame
    void Update(){ //EL RUN DE LOS APPLETS

        velY = (float)rigidbody.velocity.y; //rigidbody es un atributo de los objetos que hace que tenga un cuerpo rigido, aplica físicas



        //ESTO ES PARA EL MOVIMIENTO EN EL MOVIL
        dirX = Input.acceleration.x*2;

       //Vector3 Movement = new Vector3(dirX, velY/18, 0);

        //FIN DEL MOVIMIENTO DEL MOVIL


        //ESTO ES PARA EL MOVIMIENTO EN ORDENADOR
        
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), velY/18, 0);
        Debug.Log(Movement);
        this.transform.position += Movement * speed * Time.deltaTime; //transform es una propiedad de los objetos basicamente para colocarlos en el espacio 
        timer += Time.deltaTime;
        if (timer > 0.5f) {
            robotAnimator.SetBool("Platform", false);
            timer = 0.0f;
        }
    }

    void OnCollisionEnter(Collision other) //FUNCION PARA QUE REBOTE EL PERSONAJE
    {
        velX = (float)rigidbody.velocity.x;
        if (other.gameObject.tag == "Platform") {
            rigidbody.velocity = new Vector3(0, speed, 0);
            robotAnimator.SetBool("Platform", true);
        }
    }
 
}
