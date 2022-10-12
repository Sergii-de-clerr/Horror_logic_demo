using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer_helper_1 : MonoBehaviour
{
    [SerializeField] private Unlockers_controller _unlocker;
    private Lazer_Ineract_Items[] Lazers = new Lazer_Ineract_Items[8];
    private double[] Answers = { -62.5, -45, 180, -152.5, 90, 62.5, 45, 90 };
    void Start()
    {
        for (int j = 0; j < 8; j++)
        {
            Lazers[j] = transform.GetChild(j + 2).GetComponent<Lazer_Ineract_Items>();
        }
    }

    void Update()
    {
        if (_unlocker?.Is_activated == true)
        {
            for (int i = 0; i < 8; i++)
            {
                Lazers[i].gameObject.transform.eulerAngles = new Vector3(0, (float)Answers[i], 0);
            }
        }
    }
}
