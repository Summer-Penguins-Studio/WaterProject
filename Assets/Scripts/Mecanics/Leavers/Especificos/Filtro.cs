using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filtro : MonoBehaviour, ILeaver
{
    private RotateLeaver rotate;
    private Variables vars;

    public bool actionEnded()
    {
        bool ended = false;

        

        return ended;
    }

    public void activate()
    {
        if(actionEnded()){
            if(vars.filtroAgua == false){
                Debug.Log("Filtro Activo");
            }
            else {
                Debug.Log("Filtro Desactivado");
            }
            vars.filtroAgua = !vars.filtroAgua;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rotate = this.GetComponent<RotateLeaver>();
        vars = GameObject.FindGameObjectWithTag("GameController").GetComponent<Variables>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
