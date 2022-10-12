using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder_Controller : MonoBehaviour
{
    private bool _is_triggered = false;
    private Rigidbody this_Rig;
    //private GameObject this_Obg;
    void Start()
    {
        
    }

    void Update()
    {
        if(_is_triggered == true && Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Ні");
            this_Rig.velocity = Vector3.up * 10;
            //this_Obg.transform.position += Vector3.up * 10 * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"{other.gameObject.name} Розбійник");
        if (other.gameObject.GetComponent<Player_Controller>())
        {
            this_Rig = other.GetComponent<Rigidbody>();
            //this_Obg = other.gameObject;
            _is_triggered = true;
            other.gameObject.GetComponent<Player_Controller>().Is_interact = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Молоток");
        if (other.gameObject.GetComponent<Player_Controller>())
        {
            _is_triggered = false;
            other.gameObject.GetComponent<Player_Controller>().Is_interact = false;
        }
    }
}
