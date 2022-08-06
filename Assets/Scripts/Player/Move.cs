using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public LevelController controller;
    public float gravity = -9.8f;
    public float deltaMovementSpeed = 5f;
    public float jumpForce;
    private float ySpeed;
    private float xSpeed;
    private float zSpeed;
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
        movement = Vector3.zero;
        if(controller.isPlaying){
            ySpeed = gravity;
            SetGravity();
            Jump();
            Movement();
            Debug.Log("Before ySpeed:" + movement.y);
            movement.y = ySpeed;
            Debug.Log("After ySpeed:" + movement.y);
            characterController.Move(movement * Time.deltaTime);
        }
        anim.SetInteger("animation", selectorAnim);
    }

    private void Jump(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Jump");
            ySpeed = jumpForce;
        }
    }

    private void SetGravity(){
        if(characterController.isGrounded){
            ySpeed = gravity * Time.deltaTime;
        }
        else{
            ySpeed += gravity * Time.deltaTime;
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
            movement = direction * deltaMovementSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.09f);
            selectorAnim = 1;
        }
        else {
            selectorAnim = 0;
        }
    }   

    
}