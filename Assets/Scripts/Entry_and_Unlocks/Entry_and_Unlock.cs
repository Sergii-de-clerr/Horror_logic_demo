using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry_and_Unlock : MonoBehaviour
{
    [SerializeField] private Entry_controller _entry;
    [SerializeField] private Unlockers_controller _unlocker;
    void Start()
    {
        
    }

    void Update()
    {
        if (_unlocker.Is_activated == true)
        {
            _entry.Open();
        }
        else
        {
            _entry.Close();
        }
    }
}
