using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    private Vector3 posChange = new Vector3(0,0,0);
    public Transform Camera;
    
    void Start()
    {
        Debug.Log(Camera.right);
        
    }

    
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity))
        {
            transform.rotation = hit.transform.rotation;
        }

        if (Input.GetKey(KeyCode.A))
        {
            posChange += (-Camera.right);
        }
        if (Input.GetKey(KeyCode.D))
        {
            posChange += (Camera.right);
        }
        if (Input.GetKey(KeyCode.W))
        {
            posChange += (Camera.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            posChange += (-Camera.forward);
        }
        
        transform.position += (posChange.normalized * Speed * Time.deltaTime);
        posChange = new Vector3(0, 0, 0);

    }
}
