using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPro : MonoBehaviour
{
    private Rigidbody rigi;

    private new Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        rigi = this.GetComponent<Rigidbody>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Movement(){
        
    }   
}
