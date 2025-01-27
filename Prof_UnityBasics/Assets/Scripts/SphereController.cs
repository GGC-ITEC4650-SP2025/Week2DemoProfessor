using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereController : MonoBehaviour
{
    //Components Connected to the same gameObject as this one.
    Rigidbody myBod;
    ParticleSystem myPartSys;

    //Components Connected to other gameObjects.
    Transform floorTran;
    Text gameTxt;

    //public properties (initialized in the inspector)
    //public type prop2;

    //private properties
    //private type prop1;

    // Start is called before the first frame update
    void Start()
    {
        //init my components
        myBod = GetComponent<Rigidbody>();
        myPartSys = GetComponent<ParticleSystem>();

        //init other components
        floorTran = GameObject.Find("Floor").GetComponent<Transform>();
        gameTxt = GameObject.Find("GameMsg").GetComponent<Text>();

        myBod.velocity = new Vector3(1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Do Stuff
    }

    //Called when my gameObject collides with another
    //Requires at least 1 of the gameObjects to have a Rigidbody.
    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherGO = collision.gameObject;
        //Do Stuff
        print(gameObject.name + " falls onto " + otherGO.name);

        if(otherGO.name == "Cube") {
            floorTran.localScale += new Vector3(1, 0, 0);
            gameTxt.text += "O";
        }
        
    }

    //Called when my gameObject overlaps (triggers) with another
    //Requires at least 1 of the gameObjects to have a Rigidbody or CharacterController.
    private void OnTriggerEnter(Collider other)
    {
        GameObject otherGO = other.gameObject;
        //Do Stuff
        print(gameObject.name + " falls through " + otherGO.name);
        myBod.velocity = new Vector3(0, 0, 0);
        myPartSys.Play();

    }
}
