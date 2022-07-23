using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    void Awake(){
        //Singleton
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this);
        }
        else{
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void keyPressed(InputKeys key){
        switch(key){
            case InputKeys.right:
                Debug.Log("Right");
                break;
            case InputKeys.left:
                Debug.Log("Left");
                break;
            case InputKeys.up:
                Debug.Log("Up");
                break;
            case InputKeys.down:
                Debug.Log("Down");
                break;
            case InputKeys.jump:
                Debug.Log("Jump");
                break;
            default:
                break;
        }
    }
}
