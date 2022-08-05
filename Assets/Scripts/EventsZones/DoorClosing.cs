using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClosing : MonoBehaviour
{
    public GameObject door;
    public GameObject controller;
    private bool closed;
    private bool cinema;

    public int movement;
    // Start is called before the first frame update
    void Start()
    {
        closed = false;
        cinema = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(cinema){
            if(cinema && door.transform.position.y > -1){
                door.transform.Translate(new Vector3(0, 0, - 10 * Time.deltaTime));
            }
            else if(!closed){
                closed = true;
                controller.GetComponent<LevelController>().isPlaying = true;
                cinema = false;
            }
        }
    }

    public void OnTriggerEnter(Collider player){
        if(!closed && player.gameObject.CompareTag("Player")){
            cinema = true;
            controller.GetComponent<LevelController>().isPlaying = false;
        }
    }
}
