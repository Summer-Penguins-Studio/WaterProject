using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPro : MonoBehaviour
{
    public float deltaMovementSpeed;

    private Rigidbody rigi;
    private new Transform camera;
    private Vector3 movement = Vector3.zero;
    private LevelController controller;
    private Animator animator;
    private int anim;

    // Start is called before the first frame update
    void Start()
    {
        rigi = this.GetComponent<Rigidbody>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("animation", anim);
    }

    void FixedUpdate(){
        if(controller.isPlaying){
            Movement();
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
            rigi.MovePosition(this.transform.position + movement);
            //rigi.AddForce(this.transform.position + movement);
            anim = 1;
        }
        else {
            anim = 0;
        }
    }   
}
