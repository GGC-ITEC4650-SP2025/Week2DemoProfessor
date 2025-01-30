using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;

    private int score;
    private GameObject[] allBlueCols;
    private bool onGround;

    //Components Connected to the same gameObject as this one.
    Rigidbody myBod;

    void Start()
    {
        onGround = false;
        //init my components
        myBod = GetComponent<Rigidbody>();
        score = 0;
        allBlueCols = GameObject.FindGameObjectsWithTag("BlueCol");
        print("There are " + allBlueCols.Length + " Blue Collumns");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && onGround) {
            myBod.velocity += new Vector3(0, jumpPower, 0); 
        }

        float h = Input.GetAxis("Horizontal");
        Vector3 step = new Vector3(speed * h, 0, 0);
        //transform.position += step * Time.deltaTime;
        myBod.velocity += step * Time.deltaTime;

        if(Input.GetButtonDown("Fire1")) {
            if(Time.timeScale == 0)
                Time.timeScale = 1; //resume game
            else
                Time.timeScale = 0; //pause game
        }
    }

    //Called when my gameObject collides with another
    //Requires at least 1 of the gameObjects to have a Rigidbody.
    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherGO = collision.gameObject;
        if(otherGO.tag == "BlueCol") {
            score += 10;
            print("Score is " + score);
        }
        else if(otherGO.tag == "RedCol") {
            for(int i = 0; i < allBlueCols.Length; i++) {
                GameObject g = allBlueCols[i];
                Transform t = g.GetComponent<Transform>();
                t.position += new Vector3(0, 2, 0);
            }
        }
    }   

    //Called when my gameObject overlaps (triggers) with another
    //Requires at least 1 of the gameObjects to have a Rigidbody or CharacterController.
    private void OnTriggerEnter(Collider other)
    {
        GameObject otherGO = other.gameObject;
        //Do Stuff
        if(otherGO.name == "Goal")
        {
            print("Winner Winner Chicken Dinner!");
            Time.timeScale = 0;
        } 
        else if(otherGO.name == "Death")
        {
            print("Game Over!");
            Time.timeScale = 0;
        }
        else {
            onGround = true;
        }


    } 

    private void OnTriggerExit(Collider other)
    {
        GameObject otherGO = other.gameObject;
        //Do Stuff
        onGround = false;
    } 

}
