using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHandler : ScriptableObject, IStatusHandler
{
    public void keyPressed(InputKeys key){
        if(key != InputKeys.empty){
            Debug.Log("Main " + key.ToString());
            
        }   
    }
}
