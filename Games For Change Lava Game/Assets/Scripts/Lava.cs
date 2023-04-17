using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
     
public class Lava : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 lavaStartPosition;
    public Vector3 lavaStartPosition2;
    public Vector3 lavaStartPosition3;
    public Vector3 lavaStartPosition4;


    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //ReloadLevel();
            if (other.transform.position.x > -18)
            {
                startPosition = new Vector3(-23, 3, 0);
            }
            if (other.transform.position.x > 13)
            {
                startPosition = new Vector3(14, 7, 0);
            }

            other.transform.position = startPosition;
        }
        else if (other.gameObject.tag == "LavaDrop")
        {
            other.transform.position = lavaStartPosition;
            other.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else if (other.gameObject.tag == "LavaDrop2")
        {
            other.transform.position = lavaStartPosition2;
            other.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else if (other.gameObject.tag == "LavaDrop3")
        {
            other.transform.position = lavaStartPosition3;
            other.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else if (other.gameObject.tag == "LavaDrop4")
        {
            other.transform.position = lavaStartPosition4;
            other.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

/*    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }
*/
}
