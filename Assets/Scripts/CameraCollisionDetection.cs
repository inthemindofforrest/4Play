using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollisionDetection : MonoBehaviour
{
    GameManager Manager;
    public int LocationPointAmount = 0;

    private void Start()
    {
        Manager = GameManager.Manager;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
        if(collision.gameObject.tag == "Player")
        {
            Manager.CameraLocationPoint += LocationPointAmount;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag + " Trigger");
        if (other.gameObject.tag == "Player")
        {
            Manager.CameraLocationPoint += LocationPointAmount;
        }
    }
}
