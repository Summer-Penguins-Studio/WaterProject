using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLeaver : MonoBehaviour
{
    public Transform palanca;
    // Start is called before the first frame update
    void Start()
    {
        palanca.Rotate(-45, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Rotate(bool activate){
        if(activate){
            palanca.Rotate(45, 0, 0);
        }
        else {
            palanca.Rotate(-45, 0, 0);
        }
    }
}
