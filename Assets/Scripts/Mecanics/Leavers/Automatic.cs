using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Automatic : MonoBehaviour, ILeaver
{
    public GameObject controller;
    private Variables vars;
    public Text warning;

    public void activate()
    {
        Debug.Log("Automatic");
        if(vars.filtroAgua && vars.sistemaCalentamiento){
            warning.text = null;
            this.GetComponent<InterInfo>().rotate();
            vars.sistemaAutomatizado = !vars.sistemaAutomatizado;
        }
        else{
            warning.text = "No se puede activar este Sistema aún";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        vars = controller.GetComponent<Variables>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
