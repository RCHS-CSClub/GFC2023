using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationForAmo : MonoBehaviour
{
    //private float horizontalInput;
    //private int freezeSpeed;

    // Update is called once per frame
    void Update()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * Time.deltaTime * freezeSpeed * horizontalInput);
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision!");
        if (other.gameObject.tag == "LavaDrop" || other.gameObject.tag == "LavaDrop2" || other.gameObject.tag == "LavaDrop3" || other.gameObject.tag == "LavaDrop4")
        {
            Debug.Log("Should Freeze.");
            other.rigidbody.isKinematic = true;
            //other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
            //other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            //other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        }
    }
}
