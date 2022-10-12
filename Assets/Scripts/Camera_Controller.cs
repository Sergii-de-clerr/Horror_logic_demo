using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private float SenceM = 200;

    private float AngleX;
    private float AngleY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //MouseX = Input.GetAxis("Mouse X") * SenceM * Time.deltaTime;
        //MouseY = Input.GetAxis("Mouse Y") * SenceM * Time.deltaTime;

        //Player.transform.Rotate(MouseX * new Vector3(0, 1, 0));

        ////Debug.Log(MouseY);

        //if (Player.transform.rotation.y < -89 && MouseY > 0) { }
        //else if (Player.transform.rotation.y > 89 && MouseY < 0) { }
        //else
        //    transform.Rotate(-MouseY * new Vector3(1, 0, 0));

        AngleX += Input.GetAxis("Mouse X") * Time.deltaTime * SenceM;
        AngleY += Input.GetAxis("Mouse Y") * Time.deltaTime * SenceM;
        if (AngleY > 80)
            AngleY = 80;
        else if (AngleY < -80)
            AngleY = -80;
        Player.transform.eulerAngles = new Vector3(-AngleY, AngleX, 0);
        transform.eulerAngles = new Vector3(0, AngleX, 0);
    }
}
