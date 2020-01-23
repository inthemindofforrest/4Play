using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    private Vector3 posChange = new Vector3(0,0,0);
    public Transform Camera;
    public float floatHight;
    
    void Start()
    {
        Debug.Log(Camera.right);
        
    }

    
    void Update()
    {
        
       

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity))
        {
            transform.position = hit.point + new Vector3(0, floatHight, 0);

            Vector3 playerRotation = transform.rotation.eulerAngles;
            Vector3 camerRotation = Camera.rotation.eulerAngles;
            Vector3 floorRotation = hit.transform.rotation.eulerAngles;
            Quaternion newRot = new Quaternion();
            newRot.eulerAngles = new Vector3(playerRotation.x, camerRotation.y, playerRotation.z);
            transform.rotation = newRot;
            ////transform.rotation.eulerAngles = new Vector3(floorRotation.x, camerRotation.y, floorRotation.z);

            //transform.up = new Vector3( hit.transform.up.x, camerRotation.y,hit.transform.up.z);
        }

        if (Input.GetKey(KeyCode.A))
        {
            posChange += (/*-Camera.right*/ -transform.right);
        }
        if (Input.GetKey(KeyCode.D))
        {
            posChange += ( /*Camera.right*/transform.right);
        }
        if (Input.GetKey(KeyCode.W))
        {
            posChange += (/*Camera.forward*/transform.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            posChange += (/*-Camera.forward*/ -transform.forward);
        }
        
        transform.position += (posChange.normalized * Speed * Time.deltaTime);
        posChange = new Vector3(0, 0, 0);

    }
}
