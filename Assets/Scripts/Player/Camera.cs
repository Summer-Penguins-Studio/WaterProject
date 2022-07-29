using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player;
    public int height;
    public int depth;
    public Quaternion rotation;

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
        Vector3 playerPosition = new Vector3(
            player.transform.position.x,
            player.transform.position.y + height,
            this.transform.position.z
        );
        this.transform.SetPositionAndRotation(playerPosition, rotation);
    }
}
