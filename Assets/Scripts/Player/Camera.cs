using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player;
    public int height;
    public int depth;
    public Quaternion rotation;

    public GameObject controller;

    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        this.transform.SetPositionAndRotation(new Vector3(0,height,depth), rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.GetComponent<LevelController>().isPlaying){
            followPlayer();
        }

    }

    private void followPlayer(){
        Vector3 playerPosition = new Vector3(
            player.transform.position.x,
            player.transform.position.y + height,
            depth
        );
        this.transform.SetPositionAndRotation(playerPosition, rotation);
    }

    public void cinemaCover(){
        Debug.Log("Cinema");
        this.transform.SetPositionAndRotation(this.transform.position, new Quaternion(0, 180, 0, 0));
    }
}
