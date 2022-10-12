using Assets.Scripts;
using UnityEngine;

public class Lazer_Puzzle : Unlockers_controller
{
    //[SerializeField] private Unlockers_controller _unlocker;
    Warming_Items W_I;
    //private Lazer_Ineract_Items[] Lazers = new Lazer_Ineract_Items[8];
    //private double[] Answers = { -62.5, -45, 180, -152.5, 90, 62.5, 45, 90 };
    void Start()
    {
        Is_activated = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Warming_Items>())
            {
                W_I = transform.GetChild(i).GetComponent<Warming_Items>();
            }
        }
        //for (int j = 0; j < 8; j++)
        //{
        //    Lazers[j] = transform.GetChild(j + 2).GetComponent<Lazer_Ineract_Items>();
        //}
    }

    void Update()
    {
        if (W_I.IS_ACTIVATED == true)
        {
            Is_activated = true;
        }
        if (W_I.IS_ACTIVATED == false)
        {
            Is_activated = false;
        }
        //if (_unlocker?.Is_activated == true)
        //{
        //    for (int i = 0; i < 8; i++)
        //    {
        //        Lazers[0].gameObject.transform.eulerAngles = new Vector3(0, (float)Answers[i], 0);
        //    }
        //}
    }
}
