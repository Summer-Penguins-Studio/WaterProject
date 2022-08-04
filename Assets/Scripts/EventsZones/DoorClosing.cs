using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClosing : MonoBehaviour
{
    public GameObject door;
    private bool closed;

    public int movement;
    // Start is called before the first frame update
    void Start()
    {
        closed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider player){
        if(!closed && player.gameObject.CompareTag("Player")){
            door.transform.Translate(new Vector3(0, 0, - movement));
            closed = true;
        }
    }
}
