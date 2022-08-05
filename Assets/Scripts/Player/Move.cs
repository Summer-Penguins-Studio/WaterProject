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

    public GameObject keyCap;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playing = false;
    }
    void Update()
    {
        if(controller.isPlaying){
            Movement();
            characterController.Move(new Vector3(0, gravity, 0) * Time.deltaTime);
        }
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
            //movement.y += gravity * Time.deltaTime;
            characterController.Move(movement);
        }
    }   

    public void OnTriggerStay(Collider colision){
        if(colision.gameObject.CompareTag("Inter")){
            keyCap.GetComponent<KeyCap>().showAction(colision.gameObject.GetComponent<InterInfo>().key, 
            colision.gameObject.GetComponent<InterInfo>().message, 
            colision.gameObject.GetComponent<InterInfo>().activate);
        }
    }

    public void OnTriggerExit(Collider colision){
        if(colision.gameObject.CompareTag("Inter")){
            keyCap.GetComponent<KeyCap>().hide();
        }
    }
}