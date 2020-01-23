using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChild : MonoBehaviour
{
    GameManager Manager;
    public GameObject Child;
    DIRECTION Direction;

    SpawnChild(DIRECTION _direction)
    {
        Direction = _direction;
    }

    public void OnEnable()
    {
        Manager = GameManager.Manager;



        GameObject TempChild = Instantiate(Child, transform.parent);
        TempChild.GetComponent<Children>().Target = Manager.Player;
        TempChild.transform.position = transform.GetChild(0).transform.position;
        Destroy(transform.GetChild(0).gameObject);
    }
}
