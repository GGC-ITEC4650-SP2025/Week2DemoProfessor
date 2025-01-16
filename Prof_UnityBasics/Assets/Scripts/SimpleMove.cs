using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public Vector3 step;
    //public float moveTime;
    //private float timeLeft;

    public float moveDist;
    private float distLeft;

    // Start is called before the first frame update
    void Start()
    {
        //timeLeft = moveTime;
        distLeft = moveDist;
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
        if(distLeft > 0) {
            transform.position += (step * Time.deltaTime);
            distLeft -= step.magnitude * Time.deltaTime;
        }
        else {
            step = -1 * step;
            distLeft = moveDist;
        }





    }
}
