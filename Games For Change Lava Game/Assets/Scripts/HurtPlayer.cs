using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive = 1;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            FindObjectOfType<LivesSystem>().hurtPlayer(damageToGive);
    }
}