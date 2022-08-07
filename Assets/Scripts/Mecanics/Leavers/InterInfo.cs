using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterInfo : MonoBehaviour
{
    public string message;
    public string key;
    public bool active;
    public ELeaver leaver;
    private Variables vars;
    // Start is called before the first frame update
    void Start()
    {
        vars = GameObject.FindGameObjectWithTag("GameController").GetComponent<Variables>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
