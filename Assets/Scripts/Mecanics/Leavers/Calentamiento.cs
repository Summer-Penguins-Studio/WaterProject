using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calentamiento : MonoBehaviour, ILeaver
{
    public GameObject cover;
    public GameObject controller;
    private bool cinema;
    private bool active;
    private bool firstTime = true;
    public Camera cam;
    public void activate(){
        cinema = true;
        if(firstTime){
            firstTime = false;
            Debug.Log("First Time");
            cam.cinemaCover();
        }
        controller.GetComponent<LevelController>().isPlaying = false;
        if(active == true){
            active = false;
        }
        else {
            active = true;
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
