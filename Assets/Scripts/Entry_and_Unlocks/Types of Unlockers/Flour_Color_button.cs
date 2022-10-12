using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flour_Color_button : Unlockers_controller
{
    //[SerializeField] public bool Is_activated;

    void Start()
    {
        //Is_activated = IS_activated;
        if (Is_activated != true)
        {
            this.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            this.GetComponent<Renderer>().material.color = Color.green;
        }
    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player_Controller>())
        {
            transform.position -= new Vector3(0, 0.05f, 0);
            Swich_Color();
        }
    }
    public void Swich_Color()
    {
        if (Is_activated != true)
        {
            this.GetComponent<Renderer>().material.color = Color.green;
            Is_activated = true;
        }
        else
        {
            this.GetComponent<Renderer>().material.color = Color.red;
            Is_activated = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player_Controller>())
        {
            transform.position += new Vector3(0, 0.05f, 0);
        }
    }
}
