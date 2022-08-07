using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contaminada : MonoBehaviour, ILeaver
{
    private Variables vars;
    public GameObject controller;
    public void activate()
    {
        vars.aguaContaminada = !vars.aguaContaminada;
    }

    // Start is called before the first frame update
    void Start()
    {
        vars = controller.GetComponent<Variables>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
