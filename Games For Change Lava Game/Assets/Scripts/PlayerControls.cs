using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControls : MonoBehaviour
{
    public UIManager UIManager;

    //Camera
    public Camera farCamera;
    public Camera closeCamera;
    public KeyCode switchKey;
    private bool cameraSwitched = false;

    //Player Movement
    private float playerSpeed = 6f;
    private float horizontalInput;
    private float verticalInput;

    //Jumping
    private float jumpForce = 10;
    public Rigidbody playerRb;
    private bool isGrounded = true;
    private bool isJumping = false;
    //    private bool Boss1Defeated = true;
    //    private bool isDoubleJumping = false;


    //Shooting

    [SerializeField]
    private Rigidbody freezerProjectilePrefab;
    [SerializeField]
    public GameObject destroyerProjectilePrefab;
    [SerializeField]
    private Transform firePoint;
    private float launchForce = 700f;

    //Stages
    public bool Stage1;
    public bool Stage2;
    public bool Stage3;
    public bool Stage4;
    public bool Stage5;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Camera();
        BaseMovement();
        Jumping();
        Shooting();
        Stage();
    }

    void LoadNextLevel()
    {
        int currentScenedIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentScenedIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void Stage()
    {
        if (transform.position.x > -18)
        {
            UIManager.SetStage(2);
        }
        if (transform.position.x > -11)
        {
            UIManager.SetStage(3);
        }
        if (transform.position.x > 13)
        {
            UIManager.SetStage(4);
        }
        if (transform.position.x > 25)
        {
            UIManager.SetStage(5);
        }
    }

    void Camera()
    {
        if (Input.GetKeyDown(switchKey) && cameraSwitched == false)
        {
            SwitchCamera();
            cameraSwitched = true;
        }
        else if (Input.GetKeyDown(switchKey) && cameraSwitched)
        {
            SwitchCamera();
            cameraSwitched = false;
        }
    }

    void SwitchCamera()
    {
        farCamera.enabled = !farCamera.enabled;
        closeCamera.enabled = !closeCamera.enabled;
    }

    void BaseMovement()
    {
        if (cameraSwitched == false)
        {
            //Moving left and right
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * playerSpeed * horizontalInput);

            //Moving forwards and backwards
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed * verticalInput);
        }
        else //Makes sure that when cameras are swiched, movement remains relative to view
        {
            //Moving left and right
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.back * Time.deltaTime * playerSpeed * horizontalInput);

            //Moving forwards and backwards
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.right * Time.deltaTime * playerSpeed * verticalInput);
        }
    }

    void Jumping()
    {
        //Single Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }

        //Double Jumping
        /*        if (Input.GetKeyDown(KeyCode.Space) && isJumping = true && Boss1Defeated = true)
                {
                    playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    isDoubleJumping = true;
                }
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal == Vector3.up || collision.gameObject.tag == "LavaDrop" || collision.gameObject.tag == "LavaDrop2" || collision.gameObject.tag == "LavaDrop3" || collision.gameObject.tag == "LavaDrop4")
        {
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("You won!");
            LoadNextLevel();
        }
    }

    void Shooting()
    {
            //(Freeze) Shooter
        if (Input.GetKeyDown(KeyCode.U))
        {
            //            Debug.Log("Should be instantiating. ");
            var projectileInstance = Instantiate(freezerProjectilePrefab, transform.position, freezerProjectilePrefab.transform.rotation);
            projectileInstance.AddForce(firePoint.right * launchForce);
        }

            //(Destroy Ice) Shooter
        if (Input.GetKeyDown(KeyCode.I))
        {
            //Debug.Log("Should be instantiating destroy shooter. ");
            Instantiate(destroyerProjectilePrefab, transform.position, destroyerProjectilePrefab.transform.rotation);
        }

    }
}
