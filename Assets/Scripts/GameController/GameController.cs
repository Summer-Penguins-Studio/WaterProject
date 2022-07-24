using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public IStatusHandler statusHandler;

    private IDictionary<Status, IStatusHandler> statusHash = new Dictionary<Status, IStatusHandler>();

    void Awake(){
        //Singleton
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this);
            //Rest of the Awake
            awake();
        }
        else{
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        statusHandler = statusHash[Status.main];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void awake(){
        //Initialize every Status Handler
        statusHash.Add(Status.main, ScriptableObject.CreateInstance<MainHandler>());
        statusHash.Add(Status.pause, ScriptableObject.CreateInstance<PauseHandler>());
        statusHash.Add(Status.level, ScriptableObject.CreateInstance<LevelHandler>());
    }

    private void keyInterpreter(InputKeys key){
        statusHandler.keyPressed(key);    
    }

    public void changeStatus(Status status){
        statusHandler = statusHash[status];
        Debug.Log("New Status " + status.ToString());
    }

}
