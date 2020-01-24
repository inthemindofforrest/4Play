using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameManager Manager;

    public int PanSpeed = 1;
    public int DistanceFromTarget = 1;
    public Transform Target;

    public int SideLock = 10;

    public bool UpdateLoc = false;


    private void Start()
    {
        Manager = GameManager.Manager;
    }

    void Update()
    {
        Vector3 TempCameraPos = Manager.CameraLocations[Manager.CameraLocationPoint].position;

        Vector3 NewCameraPos = TempCameraPos + ((Mathf.Abs(transform.forward.x) > Mathf.Abs(transform.forward.z))? 
            new Vector3(0, 0, Mathf.Clamp(Manager.Player.transform.position.z - TempCameraPos.z, -SideLock, SideLock)) :
            new Vector3(Mathf.Clamp(Manager.Player.transform.position.x - TempCameraPos.x, -SideLock, SideLock), 0, 0));

        transform.position = Vector3.Lerp(transform.position, NewCameraPos, 1 * Time.deltaTime);
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
    }
}
