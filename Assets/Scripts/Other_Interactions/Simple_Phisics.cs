using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_Phisics : MonoBehaviour
{
    private float ray_lenth = 0.1f;
    private float speed = 1;
    private bool Is_On_Floor = false;
    void Start()
    {
        ray_lenth = transform.localScale.y / 2f;
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, -transform.up * ray_lenth, out var hit, ray_lenth, -1, QueryTriggerInteraction.Ignore))
        {
            Is_On_Floor = true;
        }
        else
        {
            Is_On_Floor = false;
        }
        if (Is_On_Floor == false)
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
    }
}
