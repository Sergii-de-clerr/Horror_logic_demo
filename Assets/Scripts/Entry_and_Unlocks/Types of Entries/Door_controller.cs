using Assets.Scripts;
using TMPro;
using UnityEngine;

public class Door_controller : Entry_controller
{
    private bool _is_triggered;
    [SerializeField]
    private GameObject Sharnir;
    [SerializeField] private TextMeshProUGUI Press_F;
    private Vector3 _temp_v = new Vector3(0, -1, 0);
    private const float angle_ogr = 90;
    private float curangle = 0;
    [SerializeField]
    private float Speed = 20;
    void Start()
    {
        _is_triggered = false;
        if (this.gameObject.GetComponent<Entry_and_Unlock>())
        {
            this.gameObject.GetComponent<BoxCollider>().size = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((_is_triggered == true) && (Input.GetKeyDown(KeyCode.F)))
        {
            //Debug.Log("Молоток");
            _temp_v *= -1;
            if (_temp_v == new Vector3(0, -1, 0))
            {
                Press_F.text = "Press F to open";
            }
            else if (_temp_v == new Vector3(0, 1, 0))
            {
                Press_F.text = "Press F to close";
            }
        }
        if ((_temp_v == new Vector3(0, 1, 0)) && (curangle < angle_ogr))
        {
            Sharnir.transform.Rotate((Time.deltaTime * Speed) * _temp_v);
            curangle += Time.deltaTime * Speed;
        }
        else if ((_temp_v == new Vector3(0, -1, 0)) && (curangle > 0))
        {
            Sharnir.transform.Rotate((Time.deltaTime * Speed) * _temp_v);
            curangle -= Time.deltaTime * Speed;
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

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"{other.gameObject.name} Розбійник");
        if (other.gameObject.GetComponent<Player_Controller>())
        {
            if (_temp_v == new Vector3(0, -1, 0))
            {
                Press_F.text = "Press F to open";
            }
            else if (_temp_v == new Vector3(0, 1, 0))
            {
                Press_F.text = "Press F to close";
            }
            _is_triggered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Молоток");
        if (other.gameObject.GetComponent<Player_Controller>())
        {
            Press_F.text = "";
            _is_triggered = false;
        }
    }
}
