using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    Rigidbody this_Rig;
    public bool Is_interact;

    //public static Player_Controller LocalPlayer { get; protected set; }
    private void Start()
    {
        this_Rig = transform.GetComponent<Rigidbody>();
        Is_interact = false;
    }
    void Update()
    {
        Vector3 res = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            res += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            res += -transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            res += -transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            res += transform.right;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.localScale -= new Vector3(0, 0.15f, 0);
            speed /= 3f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            transform.localScale += new Vector3(0, 0.15f, 0);
            speed *= 3f;
        }
        //transform.position += res * speed * Time.deltaTime;
        //this_Rig.velocity = res.normalized * speed;
        Debug.DrawRay(transform.position, new Vector3(0, -1.4f, 0));
        if ((Is_interact == false) && 
            (!Physics.Raycast(transform.position, new Vector3(0, -1.4f, 0), out var hit, 1.4f, -1, QueryTriggerInteraction.Ignore)))
        {
            //Debug.Log("Так");
            //Debug.DrawRay(transform.position, new Vector3(0, -2f, 0));
            this_Rig.velocity = (res.normalized + Vector3.down) * speed;
        }
        else
        {
            this_Rig.velocity = res.normalized * speed;
        }
    }
}
