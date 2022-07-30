using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject playUI;

    public bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mainMenu(){
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void pause(){
        isPlaying = false;
        pauseUI.SetActive(true);
    }

    public void play(){
        isPlaying = true;
        pauseUI.SetActive(false);
    }
}
