using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask_Follow_Contloller : MonoBehaviour
{
    private GameObject Enemy;
    private bool _is_triggered = false;
    private bool _is_locked = false;
    void Start()
    {
        
    }

    void Update()
    {
        if ((_is_triggered == true) && (_is_locked == false))
        {
            Vector3 res = Enemy.transform.position - transform.position;
            if (res.x > 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, Rad_To_Degrees(Math.Acos((Cos_2_Vec(new Vector2(res.x, res.z), new Vector2(0, 1))))), 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, -Rad_To_Degrees(Math.Acos((Cos_2_Vec(new Vector2(res.x, res.z), new Vector2(0, 1))))), 0);
            }
        }
    }

    public void Lock()
    {
        _is_locked = true;
    }

    public void Unlock()
    {
        _is_locked = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player_Controller>())
        {
            Enemy = other.gameObject;
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

    double Cos_2_Vec(Vector2 a, Vector2 b)
    {
        double res_u = a.x * b.x + a.y * b.y;
        double res_d = Math.Sqrt(a.x * a.x + a.y * a.y) * Math.Sqrt(b.x * b.x + b.y * b.y);
        return (res_u / res_d);
    }

    double Cos_3_Vec(Vector3 a, Vector3 b)
    {
        double res_u = a.x * b.x + a.y * b.y + a.z * b.z;
        double res_d = Math.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z) * Math.Sqrt(b.x * b.x + b.y * b.y + b.z * b.z);
        return (res_u / res_d);
    }

    float Rad_To_Degrees(double v)
    {
        return (float)(v * (180 / Math.PI));
    }
}
