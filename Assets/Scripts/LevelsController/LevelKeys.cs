using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelKeys : MonoBehaviour
{
    private LevelController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(controller.isPlaying){
                controller.pause();
            }
            else {
                controller.play();
            }
        }
    }
}
