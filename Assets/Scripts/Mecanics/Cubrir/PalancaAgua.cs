using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaAgua : MonoBehaviour
{
    public float speed;

    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
            if(transform.localScale.x < 3f && transform.localScale.y < 3f){
                transform.localScale = new Vector3(transform.localScale.x + speed, transform.localScale.y + speed, transform.localScale.z);
            }
            if(transform.localScale.z < 2.1f){
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + speed);
            }
        }
        else {
            if(transform.localScale.x > 1f && transform.localScale.y > 1f){
                transform.localScale = new Vector3(transform.localScale.x - speed, transform.localScale.y - speed, transform.localScale.z);
            }
            if(transform.localScale.z > 1f){
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z - speed);
            }
        }
        
        if(transform.localScale == new Vector3(1, 1, 1) && active == false){
            GameObject.Destroy(this);
        }
    }

    public void Desapear(){
        active = false;
    }
}
