using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    public Component doorcolliderhere;
    public GameObject keygone;
    public ParticleSystem splash;
    
    // Start is called before the first frame update
    void Start()
    {
        splash.Stop();
    }

    // Update is called once per frame
    void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E))
        {
            doorcolliderhere.GetComponent<BoxCollider>().enabled = true;
            keygone.SetActive(false);
            splash.Play();

        }


    }
}
