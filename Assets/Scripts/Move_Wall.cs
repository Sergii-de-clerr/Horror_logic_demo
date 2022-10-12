using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Wall : MonoBehaviour
{
    private const float time_ogr = 5;
    private float curtime = 0;
    private Vector3 _temp_v = new Vector3(1, 0, 0);
    void Start()
    {
        
    }

    void Update()
    {
        curtime += Time.deltaTime;
        if (curtime > time_ogr)
        {
            curtime = 0;
            _temp_v *= -1;
        }
        transform.position += _temp_v * Time.deltaTime;
    }
}
