using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelHandler : ScriptableObject, IStatusHandler
{
    public void keyPressed(InputKeys key){
        if(key == InputKeys.back){
            GameController.instance.changeStatus(Status.pause);
            GameController.instance.pause(true);
        }
    }
}
