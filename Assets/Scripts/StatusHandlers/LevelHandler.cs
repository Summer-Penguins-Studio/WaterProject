using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : ScriptableObject, IStatusHandler
{
    public void keyPressed(InputKeys key){
        if(key != InputKeys.empty)
            Debug.Log("Level " + key.ToString());
    }
}
