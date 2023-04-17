using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //void OnCollisionEnter(Collision other)
    //{

    //    GetComponent<MeshRenderer>().material.color = Color.red;


    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered!");
        if (other.gameObject.tag == "Player")
            GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
