using System.Collections.Generic;
using UnityEngine;

public class Domino_controller : MonoBehaviour
{
    [SerializeField] private int LeftNum = 0;
    [SerializeField] private int RightNum = 0;
    [SerializeField] private GameObject Domino_Point;
    void Start()
    {
        if (LeftNum > 6) LeftNum = 6;
        if (LeftNum < 0) LeftNum = 0;

        if (RightNum > 6) RightNum = 6;
        if (RightNum < 0) RightNum = 0;

        Create_Domino_Points(LeftNum, true);
        Create_Domino_Points(RightNum, false);
    }

    void Create_Domino_Points(int Points_Num, bool Is_left)
    {
        int scale = 1;
        if (Is_left == false)
        {
            scale = -1;
        }
        List<Vector3> pos = new List<Vector3>();
        switch (Points_Num)
        {
            case 0:
                break;
            case 1:
                pos = new List<Vector3>(){
            new Vector3(scale * 0.5f, 0.1f, 0) };
                break;
            case 2:
                pos = new List<Vector3>(){
            new Vector3(scale * 0.75f, 0.1f, scale * 0.25f),
            new Vector3(scale * 0.25f, 0.1f, scale * -0.25f) };
                break;
            case 3:
                pos = new List<Vector3>(){
            new Vector3(scale * 0.75f, 0.1f, scale * 0.25f),
            new Vector3(scale * 0.5f, 0.1f, 0),
            new Vector3(scale * 0.25f, 0.1f, scale * -0.25f) };
                break;
            case 4:
                pos = new List<Vector3>(){
            new Vector3(scale * 0.75f, 0.1f, scale * 0.25f),
            new Vector3(scale * 0.25f, 0.1f, scale * 0.25f),
            new Vector3(scale * 0.75f, 0.1f, scale * -0.25f),
            new Vector3(scale * 0.25f, 0.1f, scale * -0.25f) };
                break;
            case 5:
                pos = new List<Vector3>(){
            new Vector3(scale * 0.75f, 0.1f, scale * 0.25f),
            new Vector3(scale * 0.25f, 0.1f, scale * 0.25f),
            new Vector3(scale * 0.5f, 0.1f, 0),
            new Vector3(scale * 0.75f, 0.1f, scale * -0.25f),
            new Vector3(scale * 0.25f, 0.1f, scale * -0.25f) };
                break;
            default:
                pos = new List<Vector3>(){
            new Vector3(scale * 0.75f, 0.1f, scale * 0.25f),
            new Vector3(scale * 0.25f, 0.1f, scale * 0.25f),
            new Vector3(scale * 0.5f, 0.1f, scale * 0.25f),
            new Vector3(scale * 0.5f, 0.1f, scale * -0.25f),
            new Vector3(scale * 0.75f, 0.1f, scale * -0.25f),
            new Vector3(scale * 0.25f, 0.1f, scale * -0.25f) };
                break;
        }
        foreach (var i in pos)
        {
            var instance = Instantiate(Domino_Point);
            instance.transform.SetParent(transform, true);
            instance.transform.position = transform.position + 
                new Vector3(i.x * transform.right.x + i.z * transform.forward.x, 
                0.1f, 
                i.x * transform.right.z + i.z * transform.forward.z);
        }
    }

    //void Create_1_Domino(bool Is_left)
    //{
    //    int scale = 1;
    //    if (Is_left == false)
    //    {
    //        scale = -1;
    //    }
    //    var instance = Instantiate(Domino_Point);
    //    instance.transform.position = transform.position + new Vector3(0, 0.1f, scale * 0.5f);
    //    instance.transform.SetParent(transform);
    //}

    //void Create_2_Domino(bool Is_left)
    //{
    //    int scale = 1;
    //    if (Is_left == false)
    //    {
    //        scale = -1;
    //    }
    //    List<Vector3> pos = new List<Vector3>(){
    //        new Vector3(scale * 0.25f, 0.1f, scale * 0.75f),
    //        new Vector3(scale * -0.25f, 0.1f, scale * 0.25f) };
    //    foreach (var i in pos)
    //    {
    //        var instance = Instantiate(Domino_Point);
    //        instance.transform.position = transform.position + i;
    //        instance.transform.SetParent(transform);
    //    }
    //}

    //void Create_3_Domino(bool Is_left)
    //{
    //    int scale = 1;
    //    if (Is_left == false)
    //    {
    //        scale = -1;
    //    }
    //    List<Vector3> pos = new List<Vector3>(){
    //        new Vector3(scale * 0.25f, 0.1f, scale * 0.75f),
    //        new Vector3(0, 0.1f, scale * 0.5f),
    //        new Vector3(scale * -0.25f, 0.1f, scale * 0.25f) };
    //    foreach (var i in pos)
    //    {
    //        var instance = Instantiate(Domino_Point);
    //        instance.transform.position = transform.position + i;
    //        instance.transform.SetParent(transform);
    //    }
    //}

    //void Create_4_Domino(bool Is_left)
    //{
    //    int scale = 1;
    //    if (Is_left == false)
    //    {
    //        scale = -1;
    //    }
    //    List<Vector3> pos = new List<Vector3>(){
    //        new Vector3(scale * 0.25f, 0.1f, scale * 0.75f),
    //        new Vector3(scale * 0.25f, 0.1f, scale * 0.25f),
    //        new Vector3(scale * -0.25f, 0.1f, scale * 0.75f),
    //        new Vector3(scale * -0.25f, 0.1f, scale * 0.25f) };
    //    foreach (var i in pos)
    //    {
    //        var instance = Instantiate(Domino_Point);
    //        instance.transform.position = transform.position + i;
    //        instance.transform.SetParent(transform);
    //    }
    //}

    //void Create_5_Domino(bool Is_left)
    //{
    //    int scale = 1;
    //    if (Is_left == false)
    //    {
    //        scale = -1;
    //    }
    //    List<Vector3> pos = new List<Vector3>(){
    //        new Vector3(scale * 0.25f, 0.1f, scale * 0.75f),
    //        new Vector3(scale * 0.25f, 0.1f, scale * 0.25f),
    //        new Vector3(0, 0.1f, scale * 0.5f),
    //        new Vector3(scale * -0.25f, 0.1f, scale * 0.75f),
    //        new Vector3(scale * -0.25f, 0.1f, scale * 0.25f) };
    //    foreach (var i in pos)
    //    {
    //        var instance = Instantiate(Domino_Point);
    //        instance.transform.position = transform.position + i;
    //        instance.transform.SetParent(transform);
    //    }
    //}

    //void Create_6_Domino(bool Is_left)
    //{
    //    int scale = 1;
    //    if (Is_left == false)
    //    {
    //        scale = -1;
    //    }
    //    List<Vector3> pos = new List<Vector3>(){
    //        new Vector3(scale * 0.25f, 0.1f, scale * 0.75f),
    //        new Vector3(scale * 0.25f, 0.1f, scale * 0.25f),
    //        new Vector3(scale * 0.25f, 0.1f, scale * 0.5f),
    //        new Vector3(scale * -0.25f, 0.1f, scale * 0.5f),
    //        new Vector3(scale * -0.25f, 0.1f, scale * 0.75f),
    //        new Vector3(scale * -0.25f, 0.1f, scale * 0.25f) };
    //    foreach (var i in pos)
    //    {
    //        var instance = Instantiate(Domino_Point);
    //        instance.transform.position = transform.position + i;
    //        instance.transform.SetParent(transform);
    //    }
    //}
    private bool _is_triggered = false;
    private bool is_taken = false;
    private GameObject LocalPlayer;

    void Update()
    {
        if ((is_taken == false) && (_is_triggered == true) && (Input.GetKeyDown(KeyCode.F)))
        {
            transform.forward = LocalPlayer.transform.forward;
            transform.position = LocalPlayer.transform.position + LocalPlayer.transform.forward;
            transform.SetParent(LocalPlayer.transform);
            transform.GetComponent<Simple_Phisics>().enabled = false;
            is_taken = true;
        }
        else if ((is_taken == true) && (Input.GetKeyDown(KeyCode.F)))
        {
            transform.forward = LocalPlayer.transform.forward;
            transform.position = LocalPlayer.transform.position + LocalPlayer.transform.forward;
            transform.SetParent(null);
            transform.GetComponent<Simple_Phisics>().enabled = true;
            is_taken = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player_Controller>())
        {
            LocalPlayer = other.gameObject;
            //Press_F.text = "Press F to close";
            _is_triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player_Controller>())
        {
            //Press_F.text = "";
            _is_triggered = false;
        }
    }
}
