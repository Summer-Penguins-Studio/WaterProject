using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPro : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float gravityFactor;
    private float fall;
    public float jumpForce;
    private float hor;
    private float ver;
    private Vector3 movement;
    private Vector3 input;

    private Transform cam;
    private Vector3 camForward;
    private Vector3 camRight;
    private CharacterController player;
    private LevelController controller;
    private Animator animator;
    private int anim;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        player = this.GetComponent<CharacterController>();
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");

        input = new Vector3(hor, 0, ver);

        CamDirection();

        movement = input.x * camRight + input.z * camForward;
        movement *= speed;

        SetGravity();
        Jump();
        player.Move(movement * Time.deltaTime);

        if(hor != 0 || ver != 0){
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(camForward * ver + camRight * hor), 0.09f);
            anim = 1;
        }
        else {
            anim = 0;
        }

        if(player.velocity.y < 0 && !player.isGrounded){
            Debug.Log("Falling");
            gravity *= gravityFactor;
        }
        else {
            gravity = 50;
        }

        animator.SetInteger("animation", anim);
    }

    private void Jump(){
        if(player.isGrounded && Input.GetAxisRaw("Jump") > 0){
            fall = jumpForce;
            movement.y = fall;
        }
    }

    private void CamDirection(){
        camForward = cam.forward;
        camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    private void SetGravity(){
        if(player.isGrounded){
            fall = -gravity * Time.deltaTime;
            movement.y = fall;
        }
        else {
            fall -= gravity * Time.deltaTime;
            movement.y = fall;
        }
    }
}
