using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    //Components Connected to the same gameObject as this one.
    MeshRenderer myRend;

    public float speed;

    //public Vector3 step;
    //public float moveTime;
    //private float timeLeft;

    //public float moveDist;
    //private float distLeft;

    // Start is called before the first frame update
    void Start()
    {
        //init my components
        myRend = GetComponent<MeshRenderer>();  

        //timeLeft = moveTime;
        //distLeft = moveDist;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 up = new Vector3(0, 1, 0);
        //transform.position = transform.position + (up * Time.deltaTime);
        
        //move on a timer and reverse directions
        /*
        if(timeLeft > 0) {
            transform.position += (step * Time.deltaTime);
        } else {
            step = -1 * step;
            timeLeft = moveTime;
        }
        timeLeft -= Time.deltaTime;
        */
        /*
        if(distLeft > 0) {
            transform.position += (step * Time.deltaTime);
            distLeft -= step.magnitude * Time.deltaTime;
        }
        else {
            step = -1 * step;
            distLeft = moveDist;
        }
        */

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 vec = new Vector3(h, v, 0);
        transform.position += vec * Time.deltaTime * speed;
    }

    //Called when my gameObject collides with another
    //Requires at least 1 of the gameObjects to have a Rigidbody.
    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherGO = collision.gameObject;
        //Do Stuff
        myRend.enabled = !myRend.enabled;
    }    
}
