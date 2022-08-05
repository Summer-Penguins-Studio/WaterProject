using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject keyCap;
    public string message;
    public bool activate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider col){
        if(col.gameObject.CompareTag("Player")){
            if(col.gameObject.GetComponent<InteractableRay>().lookingInteractable()){
                keyCap.GetComponent<KeyCap>().showAction("E", message, activate);
            }
            else{
                keyCap.GetComponent<KeyCap>().hide();
            }
            
        }
    }

    public void OnTriggerExit(Collider col){
        if(col.gameObject.CompareTag("Player")){
            keyCap.GetComponent<KeyCap>().hide();
        }
    }
}
