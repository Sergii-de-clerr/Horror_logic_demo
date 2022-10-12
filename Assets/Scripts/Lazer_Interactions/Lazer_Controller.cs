using Assets.Scripts;
using UnityEngine;

public class Lazer_Controller : Lazer_Ineract_Items
{
    [SerializeField] private Unlockers_controller _unlocker;
    private GameObject Lazer;
    private Mask_Follow_Contloller Mask;
    private bool Is_Ready_To_Unlock = false;
    private bool Is_Unlock = false;
    private bool Is_Into = false;
    private float _cur_lazer_dist = 0.1f;
    [SerializeField] private float speed = 1;
    [SerializeField] private float _max_lazer_dist = 5;
    void Start()
    {
        if (_unlocker == null)
        {
            Is_Ready_To_Unlock = true;
        }
        Mask = transform.GetComponent<Mask_Follow_Contloller>();
        Lazer = transform.Find("Lazer").gameObject;
        Lazer.GetComponent<Renderer>().material.color = Color.red;
        Lazer.transform.position += 1 * transform.forward;
    }

    void Update()
    {
        if (Is_Unlock == true || _unlocker?.Is_activated == true)
        {
            Mask.Lock();
            if ((Is_Into == false) && (_cur_lazer_dist < _max_lazer_dist))
            {
                _cur_lazer_dist += Time.deltaTime * speed;
            }
            if (Physics.Raycast(Lazer.transform.position, transform.forward * _cur_lazer_dist, out var hit, _cur_lazer_dist, -1, QueryTriggerInteraction.Ignore))
            {
                Is_Into = true;
                if (transform.name != hit.transform.name)
                {
                    var NextLazer = hit.transform.gameObject.GetComponent<Lazer_Ineract_Items>();
                    NextLazer?.Activate();
                }
            }
        }
        else
        {
            if (Physics.Raycast(Lazer.transform.position, transform.forward * _cur_lazer_dist, out var hit, _cur_lazer_dist, -1, QueryTriggerInteraction.Ignore))
            {
                if (transform.name != hit.transform.name)
                {
                    var NextLazer = hit.transform.gameObject.GetComponent<Lazer_Ineract_Items>();
                    NextLazer?.Disactivate();
                }
            }
            Is_Into = false;
            Mask.Unlock();
            _cur_lazer_dist = 0.1f;
        }
        Lazer.transform.position = transform.position + _cur_lazer_dist * transform.forward;
        Lazer.transform.localScale = new Vector3(0.1f, _cur_lazer_dist, 0.1f);
    }

    public override void Activate()
    {
        if (Is_Ready_To_Unlock == true)
        {
            Is_Unlock = true;
        }
    }

    public override void Disactivate()
    {
        if (Is_Ready_To_Unlock == true)
        {
            Is_Unlock = false;
        }
    }
}
