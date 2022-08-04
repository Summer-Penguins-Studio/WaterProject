using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPoint : MonoBehaviour
{
    public GameObject keyCap;
    public string show;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider target){
        if(target.gameObject.CompareTag("Player")){
            keyCap.GetComponent<KeyCap>().show(show, "");
        }
    }
    
    private void OnTriggerExit(Collider target){
        if(target.gameObject.CompareTag("Player")){
            keyCap.GetComponent<KeyCap>().hide();
        }
    }

}
