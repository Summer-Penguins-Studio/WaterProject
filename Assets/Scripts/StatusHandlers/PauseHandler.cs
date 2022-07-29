using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : ScriptableObject, IStatusHandler
{
    public void keyPressed(InputKeys key){
        if(key == InputKeys.back){
            GameController.instance.changeStatus(Status.level);
        } 
    }
}
