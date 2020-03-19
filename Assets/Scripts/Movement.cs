using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{

    public Rigidbody rigidbody;
    float speed=9.0f;
    float velY = 0, velX = 0;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        velY = (float)rigidbody.velocity.y;

        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), velY/12, 0);

        this.transform.position += Movement * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        velX = (float)rigidbody.velocity.x;
        if (other.gameObject.tag == "Platform") {
            rigidbody.velocity = new Vector3(0, speed, 0);
        }
    }
}
