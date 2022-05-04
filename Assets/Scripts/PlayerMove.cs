using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    //Private variables
    private Camera cam;
    private Rigidbody playerRB;
    public Transform playerTrans, modelTrans;

    //Public Objects
    public Transform playerCenter;
    public Vector3 cameraOffset;
    public Image healthBar;

    //Public Variables
    public float moveSpeed, jumpForce, timeInAir, maxJumpTime, initialJump;
    public bool canJump, alive = true;

    void Start()
    {
        //Assigning some variables
        cam = Camera.main;
        playerRB = GetComponent<Rigidbody>();
        playerTrans = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BananaHealthSmall")
        {
            Destroy(other.gameObject);
            healthBar.fillAmount += 0.25f;
        }
        if (other.gameObject.tag == "BananaHealthBig")
        {
            Destroy(other.gameObject);
            healthBar.fillAmount += 0.40f;
        }
        if (other.gameObject.tag == "DeathPlane")
        {

        }
    }

    void Update()
    {

        PlayerRotation();

        //Camera offset
        //cam.transform.position = playerCenter.position + cameraOffset;



        //Jump Script
        if (Input.GetButton("Jump") && canJump == true && GetComponent<Grapple>().isGrappling == false)
        {
            /*if (timeInAir < maxJumpTime)
            {
                //At the beginning of the jump, set the velocity to make the jump more realistic
                if (timeInAir == 0)
                {
                    playerRB.AddForce(Vector3.up * initialJump, ForceMode.VelocityChange);
                }
                playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                timeInAir += Time.deltaTime;
            }*/
            //If the player lets go of space the jump stops
            if (timeInAir < maxJumpTime)
            {
                if (timeInAir == 0)
                {
                    playerRB.AddForce(Vector3.up * initialJump, ForceMode.Force);
                }
                playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Force);
                timeInAir += Time.deltaTime;
            }
            else
            {
                canJump = false;
            }
        }
        else if (Input.GetButtonUp("Jump"))
        {
            canJump = false;
        }
    }

    void PlayerRotation()
    {
        float velX = playerRB.velocity.x;
        if(velX < 0)
        {
            modelTrans.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
        }
        else if (velX > 0)
        {
            modelTrans.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
        }
    }

    private void LateUpdate()
    {
        RaycastHit hit;
        //SphereCast below the player to check for ground
        if (Physics.SphereCast(playerCenter.position, playerTrans.localScale.x / 2, Vector3.down, out hit, 0.15f) && Input.GetAxis("Jump") == 0)
        {
            Debug.Log("I am hitting");
            if (hit.collider.tag != "Pickups")
            {
                canJump = true;
                timeInAir = 0f;
                playerRB.velocity = new Vector3(0, playerRB.velocity.y, 0);
            }
        }
    }

    //Other input in fixed update
    void FixedUpdate()
    {
        if (alive == true && GetComponent<Grapple>().isGrappling == false)
        {
            YourInput();
        }
    }

    //User input
    void YourInput()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            playerRB.velocity = new Vector3(-moveSpeed, playerRB.velocity.y, 0);
        }

        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            playerRB.velocity = new Vector3(moveSpeed, playerRB.velocity.y, 0);
        }

        else if (GetComponent<Grapple>().isGrappling == false)
        {
            //playerRB.velocity = new Vector3(playerRB.velocity.x / 1.07f, playerRB.velocity.y, 0);
        }
    }
}