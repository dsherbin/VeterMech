using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControls : MonoBehaviour
{

    Vector3 offset;

    float pov;

    void Start()
    {
       offset = new Vector3(0, 2, -4);
        pov = 1;
    }


    public void ButtonClicked()
    {//first person
        if (Input.GetKey(KeyCode.Z))
            if (pov == 1) 
            {
                offset = new Vector3(0, 1/2, -1/4);

                pov = 0;
            }
            //third person
            else
            {
                offset = new Vector3(0, 2, -4);

                pov = 1;
            }

    }
} 
