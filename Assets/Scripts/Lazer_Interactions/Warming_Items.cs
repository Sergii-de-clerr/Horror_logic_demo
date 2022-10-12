using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warming_Items : Lazer_Ineract_Items
{
    public bool IS_ACTIVATED { get; protected set; }
    private float cur_color = 1;
    [SerializeField] private float speed = 0.2f;
    private bool Is_Activated = false;
    private Material R_material;
    void Start()
    {
        IS_ACTIVATED = false;
        R_material = transform.GetComponent<Renderer>().material;
        R_material.color = new Color(1 - cur_color, cur_color, 0);
    }

    void Update()
    {
        if (Is_Activated == true && cur_color > 0)
        {
            cur_color -= Time.deltaTime * speed;
        }
        else if (Is_Activated == false && cur_color < 1)
        {
            cur_color += Time.deltaTime * speed;
        }
        R_material.color = new Color(1 - cur_color, cur_color, 0);
        if (cur_color <= 0)
        {
            IS_ACTIVATED = true;
        }
        else
        {
            IS_ACTIVATED = false;
        }
    }

    public override void Activate()
    {
        Is_Activated = true;
    }

    public override void Disactivate()
    {
        Is_Activated = false;
    }
}
