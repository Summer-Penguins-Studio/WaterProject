using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float gravity = -9.8f;
    public float deltaMovementSpeed = 5f;
    public new Transform camera;
    private CharacterController characterController;
    private Vector3 movement = Vector3.zero;
    public bool playing;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playing = false;
    }
    void Update()
    {
        if(GameController.instance.playing()){
            Movement();
        }
    }

    void Movement(){
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
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
            movement.y += gravity * Time.deltaTime;
            characterController.Move(movement);
        }
    }   
}