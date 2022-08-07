using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calentamiento : MonoBehaviour, ILeaver
{
    public GameObject cover;
    public GameObject controller;
    private Variables vars;
    public Text warning;
    private bool cinema;
    private bool active;
    private bool firstTime = true;
    public Camera cam;

    void Start(){
        vars = controller.GetComponent<Variables>();
    }
    public void activate(){
        if(vars.filtroAgua){
            warning.text = null;
            cinema = true;
            controller.GetComponent<LevelController>().isPlaying = false;
            this.GetComponent<InterInfo>().rotate();
            vars.sistemaCalentamiento = !vars.sistemaCalentamiento;
            if(active == true){
                active = false;
            }
            else {
                active = true;
            }
        }
        else {
            warning.text = "El Filtro de Agua debe estar activado";
        }
    }

    void Update(){
        if(cinema){
            if(!active){
                if(cover.transform.position.y > 0){
                    cover.transform.Translate(new Vector3(0, 0, - 10 * Time.deltaTime));
                }
                else {
                    cinema = false;
                    controller.GetComponent<LevelController>().isPlaying = true;
                }
            }
            else {
                if(cover.transform.position.y < 15){
                    cover.transform.Translate(new Vector3(0, 0, 10 * Time.deltaTime));
                }
                else {
                    cinema = false;
                    controller.GetComponent<LevelController>().isPlaying = true;
                }
            }
        }
    }
}
