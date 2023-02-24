using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationForAmo : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        ShooterRotation();
    }

    void ShooterRotation()
    {
        transform.Rotate(Vector3.up * .5f);
    }
}
