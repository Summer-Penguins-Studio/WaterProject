using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class KeyCap : MonoBehaviour
{
    public GameObject decoration;
    public GameObject text;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showDecoration(){
        decoration.SetActive(true);
    }

    public void showLetter(string key){
        showDecoration();
        text.SetActive(true);
        text.GetComponent<Text>().text = key;
    }

    public void showImage(){
        showDecoration();
        image.SetActive(true);
    }

    public void hide(){
        text.SetActive(false);
        image.SetActive(false);
        decoration.SetActive(false);
    }
}
