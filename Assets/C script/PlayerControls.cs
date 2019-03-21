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
    private bool fighter = false;

    private float yRot;

    private float TF = 1;

    //Particle assets
    [SerializeField]
    private ParticleSystem Lthruster;
    [SerializeField]
    private ParticleSystem Rthruster;
    [SerializeField]
    private ParticleSystem Lglow;
    [SerializeField]
    private ParticleSystem Rglow;
    [SerializeField]
    private GameObject trail1;
    [SerializeField]
    private GameObject trail2;
    [SerializeField]
    private GameObject trail3;
    [SerializeField]
    private GameObject trail4;


    [SerializeField]
    private Animator anim;

    private Rigidbody rigidBody;

    float lockPos = 0;

    // Use this for initialization
    void Start()
    {
        Lthruster.GetComponent<ParticleSystem>().enableEmission = false;
        Rthruster.GetComponent<ParticleSystem>().enableEmission = false;
        Lglow.GetComponent<ParticleSystem>().enableEmission = false;
        Rglow.GetComponent<ParticleSystem>().enableEmission = false;



        playerSpeed = walkSpeed;
        rigidBody = GetComponent<Rigidbody>();

        TF = 1;



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (TF == 1)
            {
                TF++;
                fighter = true;

                Lthruster.GetComponent<ParticleSystem>().enableEmission = true;
                Rthruster.GetComponent<ParticleSystem>().enableEmission = true;
                Lglow.GetComponent<ParticleSystem>().enableEmission = true;
                Rglow.GetComponent<ParticleSystem>().enableEmission = true;


                playerSpeed = walkSpeed * 3;


            }
            else if (TF == 2)
            {
                TF = 1;
                fighter = false;

                Lthruster.GetComponent<ParticleSystem>().enableEmission = false;
                Rthruster.GetComponent<ParticleSystem>().enableEmission = false;
                Lglow.GetComponent<ParticleSystem>().enableEmission = false;
                Rglow.GetComponent<ParticleSystem>().enableEmission = false;

                playerSpeed = walkSpeed;

            }
        }

        Debug.Log(TF);

        //if (TF == 1)

        // {
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
        anim.SetBool("Fighter", fighter);

    }
}


     /*   else if (TF == 2)
        {
            //Second set of controls


       }

        anim.SetBool("Fighter", fighter);
    }
}
*/
