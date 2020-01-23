using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    Animation anim;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("TestSwing");
            Debug.Log("left");
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right");
        }

    }
}
