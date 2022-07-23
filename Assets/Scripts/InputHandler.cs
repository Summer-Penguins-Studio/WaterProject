using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public GameController gameController;

    void Awake(){
        gameController = GameController.instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameController.keyPressed(this.keyPressed());
    }

    public InputKeys keyPressed(){
        if(Input.GetAxis("Horizontal") > 0.001){
            return InputKeys.right;
        }
        else if(Input.GetAxis("Horizontal") < -0.001){
            return InputKeys.left;
        }
        if(Input.GetAxis("Vertical") > 0.001){
            return InputKeys.up;
        }
        else if(Input.GetAxis("Vertical") < -0.001){
            return InputKeys.down;
        }
        if(Input.GetAxis("Jump") > 0.001){
            return InputKeys.jump;
        }
        return InputKeys.empty;
    }
}
