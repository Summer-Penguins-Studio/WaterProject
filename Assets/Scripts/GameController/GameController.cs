using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public IStatusHandler statusHandler;

    private IDictionary<Status, IStatusHandler> statusHash = new Dictionary<Status, IStatusHandler>();
    private IDictionary<Scenes, string> scenesHash = new Dictionary<Scenes, string>();

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
        //Initialize Status HashMap
        statusHash.Add(Status.main, ScriptableObject.CreateInstance<MainHandler>());
        statusHash.Add(Status.pause, ScriptableObject.CreateInstance<PauseHandler>());
        statusHash.Add(Status.level, ScriptableObject.CreateInstance<LevelHandler>());
        //Initialize Scenes HahsMap
        scenesHash.Add(Scenes.main, "MainMenu");
        scenesHash.Add(Scenes.tutorial, "Tutorial");
        scenesHash.Add(Scenes.testing, "TestingScene");
    }

    private void keyInterpreter(InputKeys key){
        statusHandler.keyPressed(key);    
    }

    public bool playing(){
        return this.statusHandler is LevelHandler;
    }

    public void changeStatus(Status status){
        statusHandler = statusHash[status];
        Debug.Log("New Status " + status.ToString());
    }

    public void changeScene(Scenes scene){
        SceneManager.LoadSceneAsync(scenesHash[scene]);
        if(scene == Scenes.main){
            changeStatus(Status.main);
        }
        else if(scene == Scenes.tutorial){
            changeStatus(Status.level);
        }
        else if(scene == Scenes.level1){
            changeStatus(Status.level);
        }
        else if(scene == Scenes.testing){
            changeStatus(Status.level);
        }
    }
}
