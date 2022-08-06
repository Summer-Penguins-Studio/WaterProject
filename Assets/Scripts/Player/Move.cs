using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public LevelController controller;
    public float gravity = -9.8f;
    public float deltaMovementSpeed = 5f;
    public new Transform camera;
    private CharacterController characterController;
    private Vector3 movement = Vector3.zero;
    public bool playing;

    private Animator anim;

    private int selectorAnim;

    public GameObject keyCap;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playing = false;
        anim = this.GetComponent<Animator>();
    }
    void Update()
    {
        if(controller.isPlaying){
            Movement();
            characterController.Move(new Vector3(0, gravity, 0) * Time.deltaTime);
        }
        Debug.Log(selectorAnim);
        anim.SetInteger("animation", selectorAnim);
    }

    void Movement(){
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        if (hor != 0 || ver != 0)
        {
            Vector3 forward = camera.forward;
            forward.y = 0;
            forward.Normalize();
            Vector3 right = camera.right;
            right.y = 0;
            right.Normalize();
            Vector3 direction = forward * ver + right * hor;
            direction.Normalize();
            movement = direction * deltaMovementSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.09f);
            characterController.Move(movement);
            selectorAnim = 1;
        }
        else {
            selectorAnim = 0;
        }
    }   

    public void OnTriggerStay(Collider colision){
        if(colision.gameObject.CompareTag("Inter")){
            keyCap.GetComponent<KeyCap>().showAction(colision.gameObject.GetComponent<InterInfo>().key, 
            colision.gameObject.GetComponent<InterInfo>().message, 
            colision.gameObject.GetComponent<InterInfo>().activate);
            if(Input.GetKey(KeyCode.E) && controller.GetComponent<LevelController>().isPlaying){
                Debug.Log(colision.gameObject.GetComponent<InterInfo>().message);
                colision.gameObject.GetComponent<ILeaver>().activate();
            }
        }
    }

    public void OnTriggerExit(Collider colision){
        if(colision.gameObject.CompareTag("Inter")){
            keyCap.GetComponent<KeyCap>().hide();
        }
    }
}