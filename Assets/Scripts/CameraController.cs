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

    void Update()
    {
        //if(UpdateLoc)
        //{
            transform.position += Vector3.Lerp(transform.position, Manager.CameraLocations[Manager.CameraLocationPoint].position, 1 * Time.deltaTime);
            transform.LookAt(Target.position);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (Manager.CameraLocationPoint == 0)
                    Manager.CameraLocationPoint = 1;
                else
                    Manager.CameraLocationPoint = 0;
            }
        //}
    }
}
