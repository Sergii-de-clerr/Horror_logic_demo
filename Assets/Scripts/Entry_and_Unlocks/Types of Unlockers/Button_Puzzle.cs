using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class Button_Puzzle : Unlockers_controller
{
    //[SerializeField] private BoxCollider Door_col;
    //private Vector3 Fake_Door_col;
    private Flour_Color_button[] Puzzle_Buttons = new Flour_Color_button[9];
    void Start()
    {
        Is_activated = false;
        //Fake_Door_col = Door_col.size;
        //Door_col.size = new Vector3(0, 0, 0);
        for (int i = 0; i < 9; i++)
        {
            Puzzle_Buttons[i] = transform.GetChild(i).GetComponent<Flour_Color_button>();
        }
        //Puzzle_Buttons[0].Swich_Color();
        //Puzzle_Buttons[4].Swich_Color();
        //Puzzle_Buttons[8].Swich_Color();
    }

    void Update()
    {
        if (Is_Green())
        {
            Is_activated = true;
            //Door_col.size = Fake_Door_col;
        }
    }

    private bool Is_Green()
    {
        foreach (var f in Puzzle_Buttons)
        {
            if (f.GetComponent<Renderer>().material.color == Color.red)
                return false;
        }
        return true;
    }
}
