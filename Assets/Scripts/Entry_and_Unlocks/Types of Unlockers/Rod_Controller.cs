using Assets.Scripts;
using System;
using UnityEngine;

public class Rod_Controller : Unlockers_controller
{
    [SerializeField]
    private GameObject Sharnir;
    [SerializeField]
    private float Speed = 20;
    private bool _is_triggered;
    private float pos_ogr_max;
    private float pos_ogr_min;
    private float cur_angle;
    private float scale = -1;
    void Start()
    {
        pos_ogr_max = 60;
        pos_ogr_min = 0;
        cur_angle = pos_ogr_min;
        //Debug.Log(pos_ogr_max);
        //Debug.Log(pos_ogr_min);
    }

    void Update()
    {
        //Debug.Log(Sharnir.transform.rotation.z * (360 / Math.PI));
        if ((_is_triggered == true) && (Input.GetKeyDown(KeyCode.F)))
        {
            scale *= -1;
        }
        if (cur_angle < pos_ogr_max && scale == 1)
        {
            Sharnir.transform.Rotate(scale * Speed * Time.deltaTime * new Vector3(0, 0, 1));
            cur_angle += scale * Speed * Time.deltaTime;
        }
        else if (cur_angle > pos_ogr_min && scale == -1)
        {
            Sharnir.transform.Rotate(scale * Speed * Time.deltaTime * new Vector3(0, 0, 1));
            cur_angle += scale * Speed * Time.deltaTime;
        }
        if (cur_angle >= pos_ogr_max)
        {
            Is_activated = true;
        }
        else if (cur_angle <= pos_ogr_min)
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
