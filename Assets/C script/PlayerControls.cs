using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
    public float playerSpeed = 0.2f;

    public float walkSpeed = 0.2f;

    public float mouseSensitivity = 2f;

    public float jumpHeight = 3f;

    private bool walking = false;

    private float yRot;

    [SerializeField]
    private Animator anim;

    private Rigidbody rigidBody;

    float lockPos = 0;

    // Use this for initialization
    void Start()
    {

        playerSpeed = walkSpeed;
        rigidBody = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {

        yRot += Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, yRot, transform.localEulerAngles.z);

        walking = false;

        if (Input.GetKey(KeyCode.W))
        {
            //transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);
            rigidBody.velocity = transform.forward * playerSpeed;
            walking = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);
            rigidBody.velocity = transform.forward * playerSpeed * -1;
            walking = true;
        }


        if (Input.GetKey(KeyCode.E))
        {
            anim.Play("pick_up");
        }

        /*
         
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up * jumpHeight);
        }

        */

        anim.SetBool("isWalking", walking);
        Debug.Log(walking);
    }
}