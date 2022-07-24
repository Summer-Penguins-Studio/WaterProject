using UnityEngine;

public class InputHandler : MonoBehaviour
{
    InputKeys keyPressed;

    void Awake(){
        
    }

    // Start is called before the first frame update
    void Start()
    {
        keyPressed = InputKeys.empty;
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal
        if(Input.GetAxis("Horizontal") > 0.001){
            keyPressed = InputKeys.right;
        }
        else if(Input.GetAxis("Horizontal") < -0.001){
            keyPressed = InputKeys.left;
        }

        //Vertical
        if(Input.GetAxis("Vertical") > 0.001){
            keyPressed = InputKeys.up;
        }
        else if(Input.GetAxis("Vertical") < -0.001){
            keyPressed = InputKeys.down;
        }

        //Jump
        if(Input.GetAxis("Jump") > 0.001){
            keyPressed = InputKeys.jump;
        }

        //Testing Keys
        if(Input.GetKeyDown(KeyCode.I)){
            this.SendMessage("changeStatus", Status.main);
        }
        else if(Input.GetKeyDown(KeyCode.O)){
            this.SendMessage("changeStatus", Status.pause);
        }
        else if(Input.GetKeyDown(KeyCode.P)){
            this.SendMessage("changeStatus", Status.level);
        }

        //Send & Restart
        this.SendMessage("keyInterpreter",keyPressed);
        keyPressed = InputKeys.empty;
    }
}
