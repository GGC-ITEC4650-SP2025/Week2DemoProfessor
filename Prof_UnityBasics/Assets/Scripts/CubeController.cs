using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //Components Connected to the same gameObject as this one.
    MeshRenderer myRend;
    //ComponentType2 myCom2;

    //Components Connected to other gameObjects.
    //ComponentType2 otherCom2;
    //ComponentType3 otherCom3;

    //public properties (initialized in the inspector)
    //public type prop2;

    //private properties
    //private type prop1;

    // Start is called before the first frame update
    void Start()
    {
        //init my components
        myRend = GetComponent<MeshRenderer>();  
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
        print(gameObject.name + " got hit by " + otherGO.name);
        myRend.enabled = !myRend.enabled;
    }

    //Called when my gameObject overlaps (triggers) with another
    //Requires at least 1 of the gameObjects to have a Rigidbody or CharacterController.
    private void OnTriggerEnter(Collider other)
    {
        GameObject otherGO = other.gameObject;
        //Do Stuff
        print(gameObject.name + " got sliced through by " + otherGO.name);
    }
}
