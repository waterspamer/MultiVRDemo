using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PXRInteractor : MonoBehaviour
{

    public GameObject testObj;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            testObj.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            testObj.SetActive(true);
        }
    }
}
