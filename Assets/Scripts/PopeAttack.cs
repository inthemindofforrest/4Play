using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopeAttack : MonoBehaviour
{
    public GameObject WinScreen;
    bool OnFloor = false;
    Children ChildInsidePope;

    private void Start()
    {
        ChildInsidePope = GetComponent<Children>();
    }
    private void Update()
    {
        if(OnFloor)
        {
            ChildInsidePope.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Melee")
        {
            print("WIN!!!!!!!!!!!!!!!!!!");
            WinScreen.SetActive(true);
            GameManager.Manager.health = int.MaxValue;
        }
    }
}
