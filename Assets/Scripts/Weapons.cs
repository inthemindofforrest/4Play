using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    private Animation anim;
    public Animator Anim;
    public GameObject explosion;
    private bool boom = false;
    private bool charged = false;
    public int chargeAmount;
    GameManager Manager;
    private int lastBlast = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        Manager = GameManager.Manager;
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetBool("Swing", false);
        Anim.SetBool("AOE", false);
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("TestSwing");
            Anim.SetBool("Swing", true);
            Debug.Log("left");
        }
        if (Manager.Score >= lastBlast + chargeAmount)
        {
            charged = true;
        }
        if (Input.GetMouseButtonDown(1) && charged)
        {
            explosion.SetActive(true);
            boom = true;
            charged = false;
            lastBlast = Manager.Score;
            Anim.SetBool("AOE", true);
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
