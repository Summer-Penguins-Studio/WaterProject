using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    public bool sistemaAutomatizado;
    public bool sistemaCalentamiento;
    public bool flujoAgua;
    public bool aguaContaminada;
    public bool filtroAgua;

    // Start is called before the first frame update
    void Start()
    {
        sistemaAutomatizado = false;
        sistemaCalentamiento = false;
        flujoAgua = false;
        filtroAgua = false;
        aguaContaminada = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool asignateLeaver(ELeaver leaver){
        bool retornar = false;
        switch(leaver){
            case ELeaver.calentamiento: retornar = sistemaCalentamiento; break;
            case ELeaver.flujo: retornar = flujoAgua; break;
            case ELeaver.filtro: retornar = filtroAgua; break;
            case ELeaver.automatizado: retornar = sistemaAutomatizado; break;
            case ELeaver.contaminada: retornar = aguaContaminada; break;
        }
        return retornar;
    }
}
