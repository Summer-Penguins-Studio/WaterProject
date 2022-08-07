using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterInfo : MonoBehaviour
{
    public string message;
    public string key;
    public bool activate;

    private bool valid;
    private bool action;

    public Transform palanca;

    void Start()
    {
        palanca.Rotate(-45, 0, 0);
        valid = false;
        action = false;
    }

    void Update()
    {
        if (action)
        {
            if (valid)
            {
                palanca.Rotate(45, 0, 0);
                action = false;
            }
            else
            {
                //palanca.Rotate(45,0,0);
                action = false;
            }
        }
    }

    public void rotate()
    {
        action = true;
        valid = true;
    }

    public void fakeRotate()
    {
        action = true;
        valid = false;
    }
}
