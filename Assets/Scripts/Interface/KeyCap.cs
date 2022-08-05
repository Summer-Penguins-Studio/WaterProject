using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCap : MonoBehaviour
{
    public GameObject decoration;
    public GameObject letter;
    public GameObject image;

    public Sprite enter;
    public Sprite space;

    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void showDecoration(){
        decoration.SetActive(true);
    }

    public void showAction(string key, string message, bool activate){
        showDecoration();
        letter.SetActive(true);
        if(key.Equals("Enter") || key.Equals("Space")){
            showImage(key);
        }
        else {
            letter.GetComponent<Text>().text = key;
        }
        text.SetActive(true);
        text.GetComponent<Text>().text = "Presione [" + key + "] para " + (activate ? "activar " : "desactivar ") + message;
    }

    public void showTutorial(string key, string message){
        showDecoration();
        letter.SetActive(true);
        if(key.Equals("Enter") || key.Equals("Space")){
            showImage(key);
        }
        else {
            letter.SetActive(true);
            letter.GetComponent<Text>().text = key;
            
        }
        text.SetActive(true);
        text.GetComponent<Text>().text = "Presione [" + key + "] para " + message;
    }

    private void showImage(string key){
        image.SetActive(true);
        switch(key){
            case "Enter":
                image.GetComponent<Image>().sprite = enter;
                break;
            case "Space":
                image.GetComponent<Image>().sprite = space;
                break;
        }
        
    }

    public void hide(){
        letter.GetComponent<Text>().text = null;
        letter.SetActive(false);
        image.SetActive(false);
        decoration.SetActive(false);
        text.GetComponent<Text>().text = "";
        text.SetActive(false);
    }
}
