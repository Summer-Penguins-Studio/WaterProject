using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementPro : MonoBehaviour
{
    private enum State {normal, water, gas};

    public GameObject normalModel;
    public GameObject normalOther;
    public GameObject waterModel;
    public GameObject gasModel;

    State state;
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


    public GameObject palancaAgua;
    public GameObject llaveAgua;
    private GameObject cover;
    public GameObject keyCap;
    public Text warning;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        player = this.GetComponent<CharacterController>();
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
        animator = this.GetComponent<Animator>();
        state = State.normal;
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isPlaying){
            hor = Input.GetAxisRaw("Horizontal");
            ver = Input.GetAxisRaw("Vertical");

            input = new Vector3(hor, 0, ver);

            CamDirection();

            movement = input.x * camRight + input.z * camForward;
            movement *= speed;

            SetGravity();
            Jump();
            Watering();
            player.Move(movement * Time.deltaTime);

            if(hor != 0 || ver != 0){
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(camForward * ver + camRight * hor), 0.09f);
                anim = 1;
            }
            else {
                anim = 0;
            }

            if(player.velocity.y < 0 && !player.isGrounded){
                gravity *= gravityFactor;
            }
            else {
                gravity = 50;
            }
            if(state == State.normal){
                animator.SetInteger("animation", anim);
            }
        }
        else {
            animator.SetInteger("animation", 0);
        }
    }

    private void Jump(){
        if(player.isGrounded && Input.GetAxisRaw("Jump") > 0 && state == State.normal){
            fall = jumpForce;
            movement.y = fall;
            animator.SetBool("jumping", true);
        } else if(player.isGrounded){
            animator.SetBool("jumping", false);
        }
    }

    private void Watering(){
        if(player.isGrounded && Input.GetKeyDown(KeyCode.C)){
            if(state == State.normal){
                state = State.water;
                normalModel.SetActive(false);
                normalOther.SetActive(false);
                waterModel.SetActive(true);
            }
            else if(state == State.water){
                state = State.normal;
                normalModel.SetActive(true);
                normalOther.SetActive(true);
                waterModel.SetActive(false);
            }
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

    public void OnTriggerStay(Collider colision){
        if(colision.gameObject.CompareTag("Inter") && state == State.normal){
            keyCap.GetComponent<KeyCap>().showAction(colision.gameObject.GetComponent<InterInfo>().key, 
            colision.gameObject.GetComponent<InterInfo>().message, 
            colision.gameObject.GetComponent<InterInfo>().activate);
            if(Input.GetKeyDown(KeyCode.E) && controller.GetComponent<LevelController>().isPlaying){
                colision.gameObject.GetComponent<ILeaver>().activate();
            }
            if(Input.GetKey(KeyCode.Z) && controller.GetComponent<LevelController>().isPlaying){
                if(cover != null){
                    cover.GetComponent<PalancaAgua>().Desapear();
                }
                cover = Instantiate(palancaAgua, colision.gameObject.transform.position, colision.gameObject.transform.rotation);
            }
        }
    }

    public void OnTriggerExit(Collider colision){
        if(colision.gameObject.CompareTag("Inter")  && state == State.normal){
            keyCap.GetComponent<KeyCap>().hide();
            warning.text = null;
        }
    }
}
