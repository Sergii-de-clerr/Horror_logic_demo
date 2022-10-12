using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_controller : Entry_controller
{
    [SerializeField]
    private GameObject Sharnir;

    private Vector3 _temp_v = new Vector3(0, -1, 0);

    [SerializeField]
    private float Speed = 20;

    private float pos_ogr_max = 6;
    private float pos_ogr_min = 2;
    void Start()
    {
        
    }

    void Update()
    {
        //Debug.Log(Sharnir.transform.position);
        if ((_temp_v == new Vector3(0, 1, 0)) && (Sharnir.transform.position.y < pos_ogr_max))
        {
            Sharnir.transform.position += ((Time.deltaTime * Speed) * _temp_v);
        }
        else if ((_temp_v == new Vector3(0, -1, 0)) && (Sharnir.transform.position.y > pos_ogr_min))
        {
            Sharnir.transform.position += ((Time.deltaTime * Speed) * _temp_v);
        }
    }

    public override void Open()
    {
        _temp_v = new Vector3(0, 1, 0);
    }
    public override void Close()
    {
        _temp_v = new Vector3(0, -1, 0);
    }
}
