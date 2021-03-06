﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator Anim;

    public float Speed;
    private Vector3 posChange = new Vector3(0, 0, 0);
    public Transform Camera;
    public float floatHight;
    public bool left = false;
    private Vector3 flip = new Vector3(0, 180, 0);
    private Vector3 lastHit = new Vector3();
    GameManager Manager;
    void Start()
    {
        Manager = GameManager.Manager;

    }


    void Update()
    {
        // set the players hight above the current floor and canges the players rotation based on the cameras rotation
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 20.0f))
        {
            if (hit.collider.gameObject.tag == "Floor")
            {
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
            Anim.SetBool("Walking", true);
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
            Anim.SetBool("Walking", true);
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
            Anim.SetBool("Walking", true);
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
            Anim.SetBool("Walking", true);
            if (left)
            {
                posChange += (transform.forward);
            }
            else
            {
                posChange += (-transform.forward);
            }
        }
        if(!(Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D)))
        {
            Anim.SetBool("Walking", false);
        }
        transform.position += (posChange.normalized * Speed * Time.deltaTime);
        posChange = new Vector3(0, 0, 0);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && !collision.gameObject.GetComponent<Children>().Ragdolling)
        {
            Manager.health--;
            print("Collided with Enemy");
            if (Manager.health <= 0)
            {
                Manager.ResetGame();
            }
        }
    }
}
