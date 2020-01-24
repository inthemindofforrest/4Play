using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollisionDetection : MonoBehaviour
{
    GameManager Manager;
    public int CameraSync = 0;
    public int LocationPointAmount = 0;

    private void Start()
    {
        Manager = GameManager.Manager;
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag + " Trigger");
        if (other.gameObject.tag == "Player" && Manager.CameraLocationPoint == CameraSync)
        {
            Manager.CameraLocationPoint += LocationPointAmount;
        }
    }
}
