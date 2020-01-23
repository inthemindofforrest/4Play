using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    private Vector3 posChange = new Vector3(0,0,0);
    public Transform Camera;
    public float floatHight;
    public bool left = false;
    private Vector3 flip = new Vector3(0, 180, 0);
    private Vector3 lastHit = new Vector3();
    void Start()
    {          
    }

    
    void Update()
    {            
        // set the players hight above the current floor and canges the players rotation based on the cameras rotation
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10.0f))
        {               
            if (hit.collider.gameObject.tag == "Floor")
            {
                Debug.Log(hit.collider.gameObject.name);
                transform.position = hit.point + new Vector3(0, floatHight, 0);
                lastHit = transform.position;
                Vector3 playerRotation = transform.rotation.eulerAngles;
                Vector3 camerRotation = Camera.rotation.eulerAngles;
                Quaternion newRot = new Quaternion();
                if (left)
                {
                    newRot.eulerAngles = new Vector3(playerRotation.x, camerRotation.y + flip.y, playerRotation.z);
                    transform.rotation = newRot;
                }
                else
                {
                    newRot.eulerAngles = new Vector3(playerRotation.x, camerRotation.y, playerRotation.z);
                    transform.rotation = newRot;
                }
            }
            else
            {
                transform.position = lastHit;
            }
        }
        else
        {
            transform.position = lastHit;
        }

        //moves the player based off of wasd
        if (Input.GetKey(KeyCode.A))
        {
            if (!left)
            {
                transform.Rotate(flip);
                left = true;
                posChange += (transform.right);
            }
            else
            {
                posChange += (transform.right);
            }   
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (left)
            {
                transform.Rotate(flip);
                left = false;
                posChange += (transform.right);
            }
            else
            {
                posChange += (transform.right);
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (left)
            {
                posChange += (-transform.forward);
            }
            else
            {
                posChange += (transform.forward);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (left)
            {
                posChange += (transform.forward);
            }
            else
            {
                posChange += (-transform.forward);
            }
        }
        
        transform.position += (posChange.normalized * Speed * Time.deltaTime);
        posChange = new Vector3(0, 0, 0);

    }
}
