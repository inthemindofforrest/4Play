using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    private Animation anim;
    public GameObject explosion;
    private bool boom = false;
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
            explosion.SetActive(true);
            boom = true;
            Debug.Log("Right");
        }
        if (boom)
        {
            explosion.transform.localScale += new Vector3(.2f, .2f, .2f);
            if (explosion.transform.localScale.x > 7)
            {
                explosion.transform.localScale = new Vector3(1, 1, 1);
                explosion.SetActive(false);
                boom = false;
            }
        }

    }
}
