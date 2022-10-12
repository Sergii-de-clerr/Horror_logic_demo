using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lebedka_Controller : Unlockers_controller
{
    [SerializeField]
    private GameObject Sharnir;
    [SerializeField]
    private float Speed = 20;
    [SerializeField]
    private float Time_while_activate = 5;
    private bool _is_triggered;
    private float pos_ogr_max;
    private float pos_ogr_min;
    private float cur_ang;
    private float scale = -1;
    void Start()
    {
        pos_ogr_max = 360;
        pos_ogr_min = 0;
        cur_ang = pos_ogr_min;
    }

    void Update()
    {
        if ((_is_triggered == true) && (Input.GetKeyDown(KeyCode.F)))
        {
            scale = 1;
        }
        if (cur_ang < pos_ogr_max && scale == 1)
        {
            Sharnir.transform.Rotate(scale * Speed * Time.deltaTime * new Vector3(0, 0, 1));
            cur_ang += scale * Speed * Time.deltaTime;
        }
        else if (cur_ang > pos_ogr_min && scale == -1)
        {
            Sharnir.transform.Rotate(scale * (pos_ogr_max / Time_while_activate) * Time.deltaTime * new Vector3(0, 0, 1));
            cur_ang += scale * (pos_ogr_max / Time_while_activate) * Time.deltaTime;
        }
        if (cur_ang >= pos_ogr_max)
        {
            Is_activated = true;
            scale = -1;
        }
        else if (cur_ang <= pos_ogr_min)
        {
            Is_activated = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player_Controller>())
        {
            _is_triggered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player_Controller>())
        {
            _is_triggered = false;
        }
    }
}
