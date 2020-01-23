using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameManager Manager;

    public int PanSpeed = 1;
    public int DistanceFromTarget = 1;
    public Transform Target;

    Vector3 LeftLock;
    Vector3 RightLock;

    public bool UpdateLoc = false;


    private void Start()
    {
        Manager = GameManager.Manager;
    }

    void Update()
    {
        //if(UpdateLoc)
        //{
        transform.position = Vector3.Lerp(transform.position, Manager.CameraLocations[Manager.CameraLocationPoint].position, 1 * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Manager.CameraLocations[Manager.CameraLocationPoint].rotation, 1 * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Manager.CameraLocationPoint == 0)
                Manager.CameraLocationPoint = 1;
            else if (Manager.CameraLocationPoint == 1)
                Manager.CameraLocationPoint = 2;
            else if (Manager.CameraLocationPoint == 2)
                Manager.CameraLocationPoint = 3;
            else
                Manager.CameraLocationPoint = 0;
        }
        //}
    }
}
