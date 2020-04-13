using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{

    public Rigidbody rigidbody;
    float speed=9.0f;
    float velY = 0, velX = 0;
    public Animator robotAnimator;
    public  float timer;
    // Start is called before the first frame update
    void Start(){ // ESTO ES EL INIT DE LOS APPLETS
        
    }

    // Update is called once per frame
    void Update(){ //EL RUN DE LOS APPLETS
        
        velY = (float)rigidbody.velocity.y; //rigidbody es un atributo de los objetos que hace que tenga un cuerpo rigido, aplica físicas

        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), velY/18, 0); 

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
