using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filtro : MonoBehaviour, ILeaver
{
    private Variables vars;
    public GameObject controller;
    public GameObject water;
    public bool activated;
    public void activate()
    {
        activated = true;
        vars.filtroAgua = !vars.filtroAgua;
    }

    // Start is called before the first frame update
    void Start()
    {
        vars = controller.GetComponent<Variables>();
    }

    // Update is called once per frame
    void Update()
    {
        if(activated){
            if(water.transform.position.y < -49){
                water.transform.Translate(0, 20 * Time.deltaTime, 0);
            }
            else {
                activated = false;
            }
        }
    }
}
